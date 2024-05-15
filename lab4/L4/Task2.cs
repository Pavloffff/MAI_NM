using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Equation;
using WindowsFormsApp1.Base;
using System.Drawing.Drawing2D;
using WindowsFormsApp1.Linal;

namespace WindowsFormsApp1.L4
{
    internal class Task2
    {
        private readonly double x0;
        private readonly double x1;
        private double h;
        private List<double> c0;
        private List<double> c1;
        private List<Token> fTokens;
        private List<Token> pTokens;
        private List<Token> qTokens;
        private List<Token> exactTokens;
        private Solver solver;

        public Task2(string f, double x0, double x1, string exact,
            string constr0, string constr1, double h, string p, string q)
        {
            var lexer = new Lexer();
            var parser = new Parser();
            solver = new Solver();
            fTokens = lexer.Run(f);
            fTokens = parser.ToPostfix(fTokens);
            pTokens = lexer.Run(p);
            pTokens = parser.ToPostfix(pTokens);
            qTokens = lexer.Run(q);
            qTokens = parser.ToPostfix(qTokens);
            exactTokens = lexer.Run(exact);
            exactTokens = parser.ToPostfix(exactTokens);
            List<Token> constr0Tokens = lexer.Run(constr0);
            constr0Tokens = parser.ToPostfix(constr0Tokens);
            c0 = solver.GetConstraints(constr0Tokens);
            List<Token> constr1Tokens = lexer.Run(constr1);
            constr1Tokens = parser.ToPostfix(constr1Tokens);
            c1 = solver.GetConstraints(constr1Tokens);
            this.x0 = x0;
            this.x1 = x1;
            this.h = h;
        }

        public string PrintStringShooting(
            string j, string etaj, string phietaj)
        {
            int pad = 20;
            string res = string.Empty;
            string value = j;
            value = value.PadRight(pad);
            res += value;
            value = etaj;
            value = value.PadRight(pad);
            res += value;
            value = phietaj;
            value = value.PadRight(pad);
            res += value;
            res += "\n";
            return res;
        }

        public string PrintStringFinite(
            string k, string xk, string yk)
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
            res += "\n";
            return res;
        }

        public const int p = 4;
        public readonly double[] a = { 0, 0, 0.5, 0.5, 1 };
        public readonly double[][] b = {
            new double[] { },
            new double[] { 0 },
            new double[] { 0, 0.5 },
            new double[] { 0, 0, 0.5 },
            new double[] { 0, 0, 0, 0.5 }
        };
        public readonly double[] c = { 0, 1.0 / 6, 1.0 / 3, 1.0 / 3, 1.0 / 6 };

        public double RungeRomberg(double i1, double i2, double h1, double h2, double p)
        {
            double k = h2 / h1;
            return (i1 - i2) / (Math.Pow(k, p) - 1);
        }

        public List<double> MakeArgs(double x, List<double> y, double addX, double addY)
        {
            var res = new List<double> { x + addX };
            res.AddRange(y.Select(val => val + addY));
            return res;
        }

        public double Dy1(List<double> x)
        {
            return x[2];
        }

        public List<List<double>> RungeKutta(List<double> yk, double l, double r, double h)
        {
            int n = yk.Count;
            var res = new List<List<double>>(n);
            for (int i = 0; i < n; i++)
            {
                res.Add(new List<double> { yk[i] });
            }

            for (double x = l; x <= r - h; x += h)
            {
                var y = res.Select(list => list.Last()).ToList();

                var K = new List<double>(new double[p + 1]);
                for (int idx = 0; idx < n; idx++)
                {
                    if (idx == 0)
                    {
                        K[1] = h * Dy1(MakeArgs(x, y, 0, 0));
                    }
                    else
                    {
                        var args = MakeArgs(x, y, 0, 0);
                        K[1] = h * solver.Solve(fTokens, args[0], args[1], args[2]);
                    }
                    for (int i = 2; i <= p; i++)
                    {
                        double add = 0;
                        for (int j = 1; j <= i - 1; j++)
                            add += b[i][j] * K[j];
                        if (idx == 0)
                        {
                            K[i] = h * Dy1(MakeArgs(x, y, a[i] * h, add));
                        }
                        else
                        {
                            var args = MakeArgs(x, y, a[i] * h, add);
                            K[i] = h * solver.Solve(fTokens, args[0], args[1], args[2]);
                        }
                    }
                    double delta = c.Skip(1).Select((ci, i) => ci * K[i + 1]).Sum();
                    res[idx].Add(res[idx].Last() + delta);
                }
            }
            return res;
        }

        public List<double> ShootingMethod(double a, double b, List<double> alpha, List<double> beta, double ya, double yb, double h)
        {
            double eps = 0.00001;

            Func<double, double> phi = eta =>
            {
                List<double> args;
                if (Math.Abs(beta[0]) > eps)
                    args = new List<double> { eta, (ya - alpha[0] * eta) / beta[0] };
                else
                    args = new List<double> { ya / alpha[0], eta };

                List<List<double>> yk = RungeKutta(args, a, b, h);
                return alpha[1] * yk[0].Last() + beta[1] * yk[1].Last() - yb;
            };

            double n0 = 10, n1 = -1;
            double phi0 = phi(n0);
            double phi1 = phi(n1);
            double n;

            while (true)
            {
                n = n1 - ((n1 - n0) / (phi1 - phi0)) * phi1;
                double phij = phi(n);
                if (Math.Abs(phij) < eps)
                    break;
                n0 = n1;
                n1 = n;
                phi0 = phi1;
                phi1 = phij;
            }

            List<double> args2;
            if (Math.Abs(beta[0]) > eps)
                args2 = new List<double> { n, (ya - alpha[0] * n) / beta[0] };
            else
                args2 = new List<double> { ya / alpha[0], n };

            List<List<double>> res = RungeKutta(args2, a, b, h);
            return res[0];
        }

        public Vector FiniteDifferenceMethod(double _h)  // [y; y'; c]
        //public string FiniteDifferenceMethod(double _h)  // [y; y'; c]
        {
            int n = Convert.ToInt32((x1 - x0) / _h);
            Linal.Matrix A = new Linal.Matrix(n + 1);
            Vector B = new Vector(n + 1);
            A[0, 0] = c0[0] * _h - c1[0];
            A[0, 1] = c1[0];
            B[0] = _h * c0[2];
            double x = x0 + _h;
            for (int i = 1; i < n; i++)
            {
                A[i, i + 1] = 1 + solver.Solve(pTokens, x, 0, 0) * _h / 2;
                A[i, i] = -2 + _h * _h * solver.Solve(qTokens, x, 0, 0);
                A[i, i - 1] = 1 - solver.Solve(pTokens, x, 0, 0) * _h / 2;
                B[i] = _h * _h * 0;
                x += _h;
            }
            A[n, n - 1] = (-1) * c1[1];
            A[n, n] = c0[1] * _h + c1[1];
            B[n] = _h * c1[2];

            return TMA.Solve(A, B);
        }

        public string Run()
        {
            string res = string.Empty;

            res += "Shooting method\n\n";

            double h1 = h;
            List<double> y1 = ShootingMethod(x0, x1, new List<double> { c0[0], c0[1] }, new List<double> { c1[0], c1[1] }, c0[2], c1[2], h1);

            res += PrintStringShooting("k", "x(x)", "y(k)");
            double xk = x0;
            for (int i = 0; i < y1.Count; i++)
            {
                res += PrintStringShooting(i.ToString(), Str.Parse(xk), Str.Parse(y1[i]));
                xk += h;
            }
            res += "\n";

            double h2 = h / 2;
            List<double> y2 = ShootingMethod(x0, x1, new List<double> { c0[0], c0[1] }, new List<double> { c1[0], c1[1] }, c0[2], c1[2], h2);
            double errorShooting = (RungeRomberg(y1[y1.Count - 1], y2[y2.Count - 1], h1, h2, 4)) / (Math.Pow(2, 2) - 1);
            res += $"Estimated error using Runge-Romberg for Shooting Method: {errorShooting}\n\n";

            res += "Finite Difference method:\n\n";
            Vector ansFD = FiniteDifferenceMethod(h);

            double x = x0;
            res += PrintStringFinite("k", "x(k)", "y(k)");
            int n = Convert.ToInt32((x1 - x0) / h);
            for (int i = 0; i < ansFD.Rows; i++)
            {
                res += PrintStringFinite(i.ToString(), Str.Parse(x), Str.Parse(ansFD[i]));
                x += h;
            }
            Vector ansFD2 = FiniteDifferenceMethod(h / 2);
            int n2 = Convert.ToInt32((x1 - x0) / (h / 2));
            double errorFinite = (ansFD[n] - ansFD2[n2]) / (Math.Pow(2, 2) - 1);
            res += $"Estimated error using Runge-Romberg for Finite Difference Method: {errorFinite}\n\n";

            return res;
        }
    }
}
