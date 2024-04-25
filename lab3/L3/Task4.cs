using app.Equation;
using app.Linal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.L3
{
    internal class Task4
    {
        private readonly List<double> X;
        private readonly List<double> fX;
        private readonly double xStar;

        public Task4(List<double> x, List<double> y, double xStar)
        {
            X = x;
            fX = y;
            this.xStar = xStar;
        }

        private static Polynomial LagrangeInterpolation(List<double> x, List<double> y)
        {
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
            }
            return new Polynomial(interpolation);
        }

        public string Run(int d)
        {
            string res = string.Empty;
            int n = X.Count;
            List<Polynomial> polynomials = new List<Polynomial>();
            for (int i = 0; i < n - d; i++)
            {
                List<double> x = new List<double>();
                List<double> y = new List<double>();
                for (int j = 0; j <= d; j++)
                {
                    x.Add(X[i + j]);
                    y.Add(fX[i + j]);
                }
                polynomials.Add(LagrangeInterpolation(x, y));
                for (int j = 0; j < d; j++)
                {
                    List<double> tmp = new List<double>();
                    for (int k = 1; k < polynomials[i].Size(); k++)
                    {
                        tmp.Add(k * polynomials[i][k]);
                    }
                    polynomials[i] = new Polynomial(tmp);
                }
            }
            List<double> range = X.GetRange(1, X.Count - d - 1);
            int idx = range.BinarySearch(xStar);
            if (idx < 0)
            {
                idx = ~idx;
            }
            if (idx >= range.Count)
            {
                idx = ~idx - 1;
            }
            res += "y";
            for (int i = 0; i < d; i++)
            {
                res += "'";
            }
            res += $"({xStar}) = ";
            res += polynomials[idx].Calculate(xStar);
            res += "\n\n";
            return res;
        }
    }
}
