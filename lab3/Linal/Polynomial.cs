using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Linal
{
    internal class Polynomial
    {
        private List<double> coefficients;

        public Polynomial(List<double> coefficients = null)
        {
            this.coefficients = coefficients ?? new List<double>();
        }

        public int Size()
        {
            return coefficients.Count;
        }

        public double this[int index]
        {
            get { return coefficients[index]; }
        }

        public double Calculate(double x)
        {
            double result = 0;
            double currentPower = 1;
            foreach (double coefficient in coefficients)
            {
                result += currentPower * coefficient;
                currentPower *= x;
            }
            return result;
        } 
        
        public static List<double> OpenBrackets(List<double> poly)
        {
            List<double> v = new List<double>(poly);
            if (v.Count == 1)
            {
                return new List<double> { v[0], 1 };
            }
            int n = v.Count;
            double last = v[v.Count - 1];
            v.RemoveAt(v.Count - 1);
            List<double> res = OpenBrackets(v);
            List<double> tmp = new List<double>(res);
            for (int i = 0; i < n; i++)
            {
                res[i] *= last;
            }
            res.Add(0);
            for (int i = 1; i <= n; i++)
            {
                res[i] += tmp[i - 1];
            }
            return res;
        }

        private static string Str(double value)
        {
            return Math.Round(value, 4).ToString("0.0000");
        }

        public override string ToString()
        {
            string res = string.Empty;
            for (int i = coefficients.Count - 1; i > 0; i--)
            {
                res += ((i == coefficients.Count - 1) ? 
                    Str(coefficients[i]) : 
                    Str(Math.Abs(coefficients[i]))) + "*x^" + 
                    i + (coefficients[i - 1] > 0 ? "+" : "-");
            }
            res += Str(Math.Abs(coefficients[0]));
            return res;
        }
    }
}
