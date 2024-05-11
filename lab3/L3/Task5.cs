using app.Equation;
using app.Linal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.L3
{
    internal class Task5
    {
        private readonly List<double> X;
        private List<Token> functionTokens;
        private readonly Solver solver;

        public Task5(List<double> x, List<Token> functionTokens)
        {
            X = x;
            this.functionTokens = functionTokens;
            solver = new Solver();
        }

        private static string Str(double value)
        {
            return Math.Round(value, 4).ToString("0.0000");
        }

        private static string PrintString(string i, string xi, string yi,
            string rect, string trp, string simp)
        {
            int pad = 20;
            string res = string.Empty;
            string value = i;
            value = value.PadRight(pad);
            res += value;
            value = xi;
            value = value.PadRight(pad);
            res += value;
            value = yi;
            value = value.PadRight(pad);
            res += value;
            value = rect;
            value = value.PadRight(pad);
            res += value;
            value = trp;
            value = value.PadRight(pad);
            res += value;
            value = simp;
            value = value.PadRight(pad);
            res += value;
            res += "\n";
            return res;
        }

        public double Runge(double s1, double s2, double h1, double h2, double p)
        {
            return s1 + (s1 - s2) / (Math.Pow((h2 / h1), p) - 1);
        }

        public (string, double[,]) Integrate(double h)
        {
            string res = string.Empty;
            res += $"h = {h}:\n\n";
            double sum = 0, X0 = X[0];

            int range = Convert.ToInt32(Math.Ceiling((X[1] - X[0]) / h)) + 1, iter = 0;
            double[,] table = new double[range, 5];
            while (X0 <= X[1])
            {
                table[iter, 0] = X0;
                table[iter, 1] = solver.Solve(functionTokens, X0, 0, 0);
                X0 += h;
                iter++;
            }
            X0 = X[0];
            iter = 0;

            while (X0 <= X[1])
            {
                table[iter, 2] = sum;
                sum += (solver.Solve(functionTokens, (2 * X0 + h) / 2, 0, 0) * h);
                X0 += h;
                iter++;
            }
            X0 = X[0];
            iter = 0;
            sum = 0;

            while (X0 <= X[1])
            {
                table[iter, 3] = sum / 2;
                sum += (solver.Solve(functionTokens, X0 + h, 0, 0) + 
                    solver.Solve(functionTokens, X0, 0, 0)) * h;
                X0 += h;
                iter++;
            }
            X0 = X[0];
            iter = 0;
            sum = 0;

            while (X0 <= X[1])
            {
                if (iter % 2 != 0)
                {
                    iter++;
                    continue;
                }
                table[iter, 4] = sum / 3;
                sum += (solver.Solve(functionTokens, X0, 0, 0) + 
                    4 * solver.Solve(functionTokens, X0 + h, 0, 0) + 
                    solver.Solve(functionTokens, X0 + 2 * h, 0, 0)) * h;
                X0 += 2 * h;
                iter++;
            }

            res += PrintString("i", "xi", "yi", "rectangles", "trapezoids", "Simpson");
            res += "\n";
            for (int i = 0; i < range; i++)
            {
                res += PrintString(i.ToString(), Str(table[i, 0]), Str(table[i, 1]),
                                   Str(table[i, 2]), Str(table[i, 3]), Str(table[i, 4]));
            }
            return (res, table);
        }

        public string Run(double h1, double h2)
        {
            string res = string.Empty;
            
            var s1 = Integrate(h1);
            res += s1.Item1.ToString();
            var s2 = Integrate(h2);
            res += "\n";
            res += s2.Item1.ToString();
            res += "\n";
            res += "Runge method:\n\n";
            int range1 = Convert.ToInt32(Math.Ceiling((X[1] - X[0]) / h1));
            int range2 = Convert.ToInt32(Math.Ceiling((X[1] - X[0]) / h2));
            res += $"Rectangles: {Runge(s1.Item2[range1, 2], s2.Item2[range2, 2], h1, h2, 2)}\n";
            res += $"Trapezoids: {Runge(s1.Item2[range1, 3], s2.Item2[range2, 3], h1, h2, 2)}\n";
            res += $"Simpson: {Runge(s1.Item2[range1, 4], s2.Item2[range2, 4], h1, h2, 2)}\n";
            return res;
        }
    }
}
