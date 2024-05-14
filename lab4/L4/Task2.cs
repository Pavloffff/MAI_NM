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
            string j, string etaj, string y, string phietaj)
        {
            int pad = 20;
            string res = string.Empty;
            string value = j;
            value = value.PadRight(pad);
            res += value;
            value = etaj;
            value = value.PadRight(pad);
            res += value;
            value = y;
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

        public (double, double) RungeKuttaMethod(double y0, double z0)
        {
            int n = Convert.ToInt32((x1 - x0) / h);
            double x = x0;
            double y = y0, yPrev = y;
            double z = z0;
            int k = 0;
            while (k < n)
            {
                double[] K = new double[4];
                double[] L = new double[4];
                for (int i = 0; i < 4; i++)
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
                    else if (i == 3)
                    {
                        K[i] = h * (z + L[i - 1]);
                        L[i] = h * solver.Solve(fTokens, x + h, y + K[i - 1], z + L[i - 1]);
                    }
                }
                z += (K[0] + 2 * K[1] + 2 * K[2] + K[3]) / 6;
                y += (L[0] + 2 * L[1] + 2 * L[2] + L[3]) / 6;
                x += h;
                k++;
                yPrev = y;
            }
            return (y, yPrev);
        }

        public string ShootingMethod()
        {
            string res = "Shooting method:\n\n";
            double leftSolve = (c0[2] - (c0[1] / h) * solver.Solve(exactTokens, h, 0, 0)) / (c0[0] + (c0[1] / h));
            double eta1 = 1.0, eta2 = 0.8;
            var y1 = RungeKuttaMethod(leftSolve, eta1);
            var y2 = RungeKuttaMethod(leftSolve, eta2);
            double phi1 = y1.Item1 - (c1[2] + (c1[1] / h) * y1.Item2) / (c1[0] + (c1[1] / h));
            double phi2 = y2.Item1 - (c1[2] + (c1[1] / h) * y2.Item2) / (c1[0] + (c1[1] / h));
            res += PrintStringShooting("j", "η(j)", "y", "Ф(η(о))");
            res += "\n";
            int j = 0;

            while (Math.Abs(phi1 - phi2) > h / 10)
            {
                res += PrintStringShooting(j.ToString(), Str.Parse(eta1), Str.Parse(y1.Item1), Str.Parse(phi1));
                res += PrintStringShooting(j.ToString(), Str.Parse(eta2), Str.Parse(y2.Item1), Str.Parse(phi2));

                double etaTmp = eta2;
                eta2 -= (eta2 - eta1) / (phi2 - phi1) * phi2;
                eta1 = etaTmp;
                y1 = RungeKuttaMethod(leftSolve, eta1);
                y2 = RungeKuttaMethod(leftSolve, eta2);
                phi1 = y1.Item1 - (c1[2] + (c1[1] / h) * y1.Item2) / (c1[0] + (c1[1] / h));
                phi2 = y2.Item1 - (c1[2] + (c1[1] / h) * y2.Item2) / (c1[0] + (c1[1] / h));
                j++;
            }
            res += PrintStringShooting(j.ToString(), Str.Parse(eta1), Str.Parse(y1.Item1), Str.Parse(phi1));
            res += PrintStringShooting(j.ToString(), Str.Parse(eta2), Str.Parse(y2.Item1), Str.Parse(phi2));
            res += "\ny = ";
            double ans = RungeKuttaMethod(leftSolve, eta2).Item1;
            res += ans.ToString();
            res += "\n";
            var y1_h = RungeKuttaMethod(leftSolve, eta2);
            double h2 = h;
            h = h / 2;
            var y2_h = RungeKuttaMethod(leftSolve, eta2);
            h = h2;
            double y_h = y1_h.Item1;
            double y_2h = y2_h.Item1;
            double errorShooting = (y_h - y_2h) / (Math.Pow(2, 4) - 1);
            res += $"Estimated error using Runge-Romberg for Shooting Method: {errorShooting}\n";
            res += "\n";

            return res;
        }

        public Vector FiniteDifferenceMethod(double _h)  // [y; y'; c]
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
            A[n, n] = c0[1] + _h * c1[1];
            B[n] = _h * c1[2];
           
            return TMA.Solve(A, B);
        }

        public string Run()
        {
            string res = string.Empty;

            res += ShootingMethod();

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
            res += $"Estimated error using Runge-Romberg for Finite Difference Method: {errorFinite}\n";

            return res;
        }
    }
}
