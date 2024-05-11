using app.Equation;
using app.Linal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace app.L3
{
    internal class Task1
    {
        private readonly List<double> X;
        private readonly List<double> fX;
        private readonly double xStar;
        private List<Token> functionTokens;
        private readonly Solver solver;

        public Task1(string y, List<double> x, double xStar)
        {
            var lexer = new Lexer();
            var parser = new Parser();
            solver = new Solver();
            functionTokens = lexer.Run(y);
            functionTokens = parser.ToPostfix(functionTokens);
            X = new List<double>(x.Count);
            fX = new List<double>(x.Count);
            for (int i = 0; i < x.Count; i++)
            {
                X.Add(x[i]);
                fX.Add(solver.Solve(functionTokens, x[i], 1, 1));
            }
            this.xStar = xStar;
        }

        private static string Str(double value)
        {
            return Math.Round(value, 4).ToString("0.0000");
        }

        private static string PrintStringLagrange(string k, string xk, string fk, string w4xk, string fkw4xk, string xStarxk)
        {
            int pad = 20;
            string res = string.Empty;
            string value = k;
            value = value.PadRight(pad);
            res += value;
            value = xk;
            value = value.PadRight(pad);
            res += value;
            value = fk;
            value = value.PadRight(pad);
            res += value;
            value = w4xk;
            value = value.PadRight(pad);
            res += value;
            value = fkw4xk;
            value = value.PadRight(pad);
            res += value;
            value = xStarxk;
            value = value.PadRight(pad);
            res += value;
            res += "\n";
            return res;
        }

        private static string PrintStringNewton(string k, string xk, string fk, string fxkxkp1, string fxkxkp1xkp2, string fxkxkp1xkp2xkp3)
        {
            int pad = 20;
            string res = string.Empty;
            string value = k;
            value = value.PadRight(pad);
            res += value;
            value = xk;
            value = value.PadRight(pad);
            res += value;
            value = fk;
            value = value.PadRight(pad);
            res += value;
            value = fxkxkp1;
            value = value.PadRight(pad);
            res += value;
            value = fxkxkp1xkp2;
            value = value.PadRight(pad);
            res += value;
            value = fxkxkp1xkp2xkp3;
            value = value.PadRight(pad);
            res += value;
            res += "\n";
            return res;
        }

        private static string LagrangeInterpolation(List<double> x, List<double> y, double xStar, Solver solver, List<Token> fTokens)
        {
            string res = "Lagrange polynomial:\n\n";
            res += PrintStringLagrange("i", "xi", "fi", "w4(xi)", "fi/w4(xi)", "X* - xi");
            res += "\n";
            int n = x.Count;
            List<double> interpolation = new List<double>(new double[n]);
            for (int i = 0; i < n; ++i)
            {
                List<double> tmp = new List<double>();
                double coef = y[i];
                for (int j = 0; j < n; ++j)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    tmp.Add((-1) * x[j]);
                    coef /= (x[i] - x[j]);
                }
                tmp = Polynomial.OpenBrackets(tmp);
                for (int j = 0; j < n; j++)
                {
                    interpolation[j] += coef * tmp[j];
                }
                res += PrintStringLagrange(i.ToString(), Str(x[i]), Str(y[i]),
                    Str(y[i] / coef), Str(coef), Str(xStar - x[i]));
            }
            var poly = new Polynomial(interpolation);
            res += "\nL3(x) = ";
            res += poly.ToString();
            res += $"\nL3({xStar}) = ";
            res += poly.Calculate(xStar);
            res += $"\n f({xStar}) = ";
            res += solver.Solve(fTokens, xStar, 1, 1);
            res += $"\nDelta(L3({xStar})) = {Str(Math.Abs(poly.Calculate(xStar) - solver.Solve(fTokens, xStar, 1, 1)))}";
            return res;
        }

        private static string NewtonInterpolation(List<double> x, List<double> y, double xStar, Solver solver, List<Token> fTokens)
        {
            string res = "Newton polynomial:\n\n";
            res += PrintStringNewton("i", "xi", "fi", "f1", "f2", "f3");
            res += "\n";
            int n = x.Count;
            List<double> interpolation = new List<double>(new double[n]);
            interpolation[0] = y[0];
            Matrix difference = new Matrix(n - 1);
            for (int i = 0; i < n - 1; i++)
            {
                difference[0, i] = (y[i] - y[i + 1]) / (x[i] - x[i + 1]);
            }
            for (int i = 1; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    difference[i, j] = (difference[i - 1, j] - difference[i - 1, j + 1]) / (x[j] - x[j + i + 1]);
                }
            }

            res += PrintStringNewton(0.ToString(), Str(x[0]), Str(y[0]), "", "", "");
            for (int i = 1; i < n; i++)
            {
                List<string> strings = new List<string>(new string[3]) { "", "", "" };
                for (int j = 0; j < n - i; j++)
                {
                    strings[j] = Str(difference[j, i - 1]);
                }
                res += PrintStringNewton(i.ToString(), Str(x[i]), Str(y[i]), strings[0] ?? "", strings[1] ?? "", strings[2] ?? "");
            }

            List<double> current = new List<double>();
            for (int i = 0; i < n - 1; i++)
            {
                current.Add(-1 * x[i]);
                List<double> tmp = Polynomial.OpenBrackets(current);
                for (int j = 0; j < tmp.Count; j++)
                {
                    interpolation[j] += difference[i, 0] * tmp[j];
                }
            }
            var poly = new Polynomial(interpolation);
            res += "\nP3(x) = ";
            res += poly.ToString();
            res += $"\nP3({xStar}) = ";
            res += poly.Calculate(xStar);
            res += $"\n f({xStar}) = ";
            res += solver.Solve(fTokens, xStar, 1, 1);
            res += $"\nDelta(P3({xStar})) = {Str(Math.Abs(poly.Calculate(xStar) - solver.Solve(fTokens, xStar, 1, 1)))}";
            return res;
        }

        public string Run()
        {
            string res = string.Empty;
            res += LagrangeInterpolation(X, fX, xStar, solver, functionTokens);
            res += "\n\n";
            res += NewtonInterpolation(X, fX, xStar, solver, functionTokens);
            return res;
        }
    }
}
