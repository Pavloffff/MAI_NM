using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Base;
using WindowsFormsApp1.Equation;

namespace WindowsFormsApp1.L4
{
    internal class Task1
    {
        private readonly double x0;
        private readonly double x1;
        private List<Token> fTokens;
        private List<Token> y0Tokens;
        private List<Token> z0Tokens;
        private List<Token> exactTokens;
        private readonly double h;
        private readonly Solver solver;

        public Task1(string f, double x0, double x1, string y0, string z0, string exact, double h)
        {
            var lexer = new Lexer();
            var parser = new Parser();
            solver = new Solver();
            fTokens = lexer.Run(f);
            fTokens = parser.ToPostfix(fTokens);
            y0Tokens = lexer.Run(y0);
            y0Tokens = parser.ToPostfix(y0Tokens);
            z0Tokens = lexer.Run(z0);
            z0Tokens = parser.ToPostfix(z0Tokens);
            exactTokens = lexer.Run(exact);
            exactTokens = parser.ToPostfix(exactTokens);
            this.x0 = x0;
            this.x1 = x1;
            this.h = h;
        }

        public string PrintStringEuler(string k, string x, string y, string dyk, string yExact, string epsK)
        {
            int pad = 20;
            string res = string.Empty;
            string value = k;
            value = value.PadRight(pad);
            res += value;
            value = x;
            value = value.PadRight(pad);
            res += value;
            value = y;
            value = value.PadRight(pad);
            res += value;
            value = dyk;
            value = value.PadRight(pad);
            res += value;
            value = yExact;
            value = value.PadRight(pad);
            res += value;
            value = epsK;
            value = value.PadRight(pad);
            res += value;
            res += "\n";
            return res;
        }

        public string PrintStringRungeKutta(
            string ki, string xk, string yki, string kki,
            string deltayk, string thetaK, string yExact, string epsK)
        {
            int pad = 20;
            string res = string.Empty;
            string value = ki;
            value = value.PadRight(pad);
            res += value;
            value = xk;
            value = value.PadRight(pad);
            res += value;
            value = yki;
            value = value.PadRight(pad);
            res += value;
            value = kki;
            value = value.PadRight(pad);
            res += value;
            value = deltayk;
            value = value.PadRight(pad);
            res += value;
            value = thetaK;
            value = value.PadRight(pad);
            res += value;
            value = yExact;
            value = value.PadRight(pad);
            res += value;
            value = epsK;
            value = value.PadRight(pad);
            res += value;
            res += "\n";
            return res;
        }

        public string PrintStringAdams(
            string  k, string xk, string yk, string f, string yExact, string epsK)
        {
            int pad = 20;
            string res = string.Empty;
            string value = k;
            value = value.PadRight(pad);
            res += value;
            value = xk;
            value = value.PadRight(pad);
            res += value;
            value = yk;
            value = value.PadRight(pad);
            res += value;
            value = f;
            value = value.PadRight(pad);
            res += value;
            value = yExact;
            value = value.PadRight(pad);
            res += value;
            value = epsK;
            value = value.PadRight(pad);
            res += value;
            res += "\n";
            return res;
        }

        public string EulerMethod(int n)
        {
            string res = string.Empty;
            res += "Euler method:\n\n";
            res += PrintStringEuler("k", "x", "y", "Δy(k)", "y_exact", "ε(k)");
            res += "\n";

            double x = x0;
            double y = solver.Solve(y0Tokens, 0, 0, 0);
            double z = solver.Solve(z0Tokens, 0, 0, 0);
            double yExact = solver.Solve(exactTokens, x, 0, 0);
            int k = 0;
            while (k < n)
            {
                double dyk = h * solver.Solve(fTokens, x, y, z);
                res += PrintStringEuler(
                    k.ToString(), Str.Parse(x), Str.Parse(y), Str.Parse(dyk),
                    Str.Parse(yExact), Str.Parse(Math.Abs(yExact - y)));

                z += dyk;
                y += z * h;
                x += h;
                yExact = solver.Solve(exactTokens, x, 0, 0);
                k++;
            }

            yExact = solver.Solve(exactTokens, x1, 0, 0);
            res += $"\nAnswer: {y}\n";
            res += $"\nRunge-Romberg Error: {Runge.Run(yExact, y, 1)}";
            return res;
        }

        public (string, List<List<double>>) RungeKuttaMethod(int n)
        {
            string res = string.Empty;
            res += "Runge-Kutta method (rank 4):\n\n";
            res += PrintStringRungeKutta(
                "k/i", "x(k)", "y_i(k)", "K_i(k)", "Δy(k)", "θ(k)", "y_exact", "ε(k)");
            res += "\n";
            List<List<double>> table = new List<List<double>>();

            double x = x0;
            double y = solver.Solve(y0Tokens, 0, 0, 0);
            double z = solver.Solve(z0Tokens, 0, 0, 0);

            table.Add(new List<double> { x });
            table.Add(new List<double> { y });
            table.Add(new List<double> { z });

            double yExact;
            int k = 0;
            while (k < n)
            {
                double[] K = new double[4];
                double[] L = new double[4];
                for (int i = 0; i < 4; i++)
                {
                    double yk = y;
                    for (int j = 0; j < i; j++)
                    {
                        yk += 0.5 * K[j];
                    }
                    yExact = solver.Solve(exactTokens, x, 0, 0);
                    double epsK = Math.Abs(y - yExact);

                    if (i == 3)
                    {
                        K[i] = h * (z + L[i - 1]);
                        L[i] = h * solver.Solve(fTokens, x + h, y + K[i - 1], z + L[i - 1]);

                        double dyk = (K[0] + 2 * K[1] + 2 * K[2] + K[3]) / 6;
                        double thetaK = Math.Abs((K[1] - K[2]) / (K[0] - K[1]));
                        res += PrintStringRungeKutta(
                            $"{k}/{i + 1}", Str.Parse(x + 0.5 * h * i), Str.Parse(yk + 0.5 * K[i]), Str.Parse(K[i]),
                            Str.Parse(dyk), Str.Parse(thetaK), "", "");
                        res += "\n";
                    }
                    else
                    {
                        if (i == 0)
                        {
                            K[i] = h * z;
                            L[i] = h * solver.Solve(fTokens, x, y, z);
                        }
                        else if (i == 1)
                        {
                            K[i] = h * (z + 0.5 * L[i - 1]);
                            L[i] = h * solver.Solve(fTokens, x + 0.5 * h, y + 0.5 * K[i - 1], z + 0.5 * L[i - 1]);
                        }
                        else if (i == 2)
                        {
                            K[i] = h * (z + 0.5 * L[i - 1]);
                            L[i] = h * solver.Solve(fTokens, x + 0.5 * h, y + 0.5 * K[i - 1], z + 0.5 * L[i - 1]);
                        }
                       
                        res += PrintStringRungeKutta(
                            $"{k}/{i + 1}", Str.Parse(x + 0.5 * h * i), Str.Parse(yk), Str.Parse(K[i]),
                            "", "", Str.Parse(yExact), Str.Parse(epsK));
                    }
                }
                z += (K[0] + 2 * K[1] + 2 * K[2] + K[3]) / 6;
                y += (L[0] + 2 * L[1] + 2 * L[2] + L[3]) / 6;
                x += h;
                table[0].Add(x);
                table[1].Add(y);
                table[2].Add(z);
                k++;
            }

            yExact = solver.Solve(exactTokens, x1, 0, 0);
            res += $"\nAnswer: {y}\n";
            res += $"\nRunge-Romberg Error: {Runge.Run(yExact, y, 4)}";
            return (res, table);
        }

        public string AdamsMethod(int n, List<List<double>> table)
        {
            string res = string.Empty;
            res += "Adams method (rank 4):\n\n";
            res += "\n";

            int k = 3;
            while (k < table[0].Count - 1)
            {
                table[2][k + 1] = table[2][k] + h * (
                    55 * solver.Solve(fTokens, table[0][k], table[1][k], table[2][k]) -
                    59 * solver.Solve(fTokens, table[0][k - 1], table[1][k - 1], table[2][k - 1]) +
                    37 * solver.Solve(fTokens, table[0][k - 2], table[1][k - 2], table[2][k - 2]) - 
                    9  * solver.Solve(fTokens, table[0][k - 3], table[1][k - 3], table[2][k - 3])
                    ) / 24;

                table[1][k + 1] = table[1][k] + h * (55 * table[2][k] - 59 * table[2][k - 1] +
                    37 * table[2][k - 2] - 9  * table[2][k - 3]) / 24;
                k++;
            }

            res += PrintStringAdams("k", "x(k)", "y(k)", "f(x(k), y(k))", "y_exact", "ε(k)");
            res += "\n";
            for (int i = 0; i < table[0].Count; i++)
            {
                double f = solver.Solve(fTokens, table[0][i], table[1][i], table[2][i]);
                double yExact1 = solver.Solve(exactTokens, table[0][i], 0, 0);
                res += PrintStringAdams(
                    i.ToString(), Str.Parse(table[0][i]), Str.Parse(table[1][i]), 
                    Str.Parse(f), Str.Parse(yExact1), Str.Parse(Math.Abs(yExact1 - table[1][i])));
            }

            double y = table[1][table[0].Count - 1];
            double yExact = solver.Solve(exactTokens, x1, 0, 0);
            res += $"\nAnswer: {y}\n";
            res += $"\nRunge-Romberg Error: {Runge.Run(yExact, y, 4)}";
            return res;
        }

        public string Run()
        {
            string res = string.Empty;
            int n = Convert.ToInt32((x1 - x0) / h);
            res += EulerMethod(n);
            res += "\n\n";
            var rungeKuttaRes = RungeKuttaMethod(n); 
            res += rungeKuttaRes.Item1;
            res += "\n\n";
            res += AdamsMethod(n, rungeKuttaRes.Item2);
            res += "\n\n";
            return res;
        }
    }
}
