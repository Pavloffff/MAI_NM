using app.Linal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.L3
{
    internal class Task2
    {
        private List<double> X;
        private List<double> fX;
        private readonly double xStar;

        public Task2(List<double> x, List<double> fX, double xStar)
        {
            X = x;
            this.fX = fX;
            this.xStar = xStar;
        }

        private static string Str(double value)
        {
            return Math.Round(value, 4).ToString("0.0000");
        }

        private static string PrintString(string i, string range, string ai, string bi, string ci, string di)
        {
            int pad = 20;
            string res = string.Empty;
            string value = i;
            value = value.PadRight(pad);
            res += value;
            value = range;
            value = value.PadRight(pad);
            res += value;
            value = ai;
            value = value.PadRight(pad);
            res += value;
            value = bi;
            value = value.PadRight(pad);
            res += value;
            value = ci;
            value = value.PadRight(pad);
            res += value;
            value = di;
            value = value.PadRight(pad);
            res += value;
            res += "\n";
            return res;
        }

        public (string, CubicSpline) Run()
        {
            string res = string.Empty;
            int n = X.Count;
            n--;
            Vector a = new Vector(n);
            Vector b = new Vector(n);
            Vector c = new Vector(n);
            Vector d = new Vector(n);
            Vector h = new Vector(n);
            for (int i = 0; i < n; i++)
            {
                h[i] = X[i + 1] - X[i];
            }
            Matrix A = new Matrix(n - 1);
            Vector B = new Vector(n - 1);
            for (int i = 0; i < n - 1; i++)
            {
                if (i > 0)
                {
                    A[i, i - 1] = h[i];
                }
                A[i, i] = 2 * (h[i] + h[i + 1]);
                if (i < n - 2)
                {
                    A[i, i + 1] = h[i + 1];
                }
                B[i] = 3 * ((fX[i + 2] - fX[i + 1]) / h[i + 1] - (fX[i + 1] - fX[i]) / h[i]);
            }
            Vector s = TMA.Solve(A, B);
            for (int i = 1; i < n; i++)
                c[i] = s[i - 1];
            for (int i = 0; i < n; i++)
                a[i] = fX[i];
            for (int i = 0; i < n - 1; i++)
                b[i] = (fX[i + 1] - fX[i]) / h[i] - 1.0 / 3.0 * (c[i + 1] + 2 * c[i]);
            b[n - 1] = (fX[n] - fX[n - 1]) / h[n - 1] - 2.0 / 3.0 * h[n - 1] * c[n - 1];
            for (int i = 0; i < n - 1; i++)
                d[i] = (c[i + 1] - c[i]) / (3 * h[i]);
            d[n - 1] = -c[n - 1] / (3 * h[n - 1]);

            res += PrintString("i", "[x_i-1, x_i]", "ai", "bi", "ci", "di");
            res +=  "\n";
            for (int i = 0; i < n; i++)
            {
                res += PrintString((i + 1).ToString(), $"[{i}, {i + 1}]", Str(a[i]), Str(b[i]), Str(c[i]), Str(d[i]));
            }

            List<Polynomial> polynomials = new List<Polynomial>();
            for (int i = 0; i < n; i++)
            {
                List<double> ansV = new List<double>(new double[4])
                {
                    [0] = a[i]
                };
                List<double> tmp = new List<double>();
                List<double> coefs = new List<double>() { a[i], b[i], c[i], d[i] };
                for (int j = 1; j < 4; j++)
                {
                    tmp.Add(-X[i]);
                    List<double> tmp1 = Polynomial.OpenBrackets(tmp);
                    for (int k = 0; k < tmp1.Count; k++)
                    {
                        ansV[k] += tmp1[k] * coefs[j];
                    }
                }
                polynomials.Add(new Polynomial(ansV));
            }
            res += "\n";
            var spline = new CubicSpline(X, polynomials);
            res += spline.ToString();
            res += "\n";
            res += spline.Calculate(xStar);
            return (res, spline);
        }
    }
}
