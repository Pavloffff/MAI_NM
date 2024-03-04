using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.Linal.Complex;

namespace app.Linal.Equation
{
    internal class Quadratic
    {
        private readonly double a, b, c;

        public Quadratic(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public Tuple<Complex.Complex, Complex.Complex> Solve()
        {
            Complex.Complex x1 = new Complex.Complex();
            Complex.Complex x2 = new Complex.Complex();

            if (a == 0)
            {
                if (b == 0)
                {
                    throw new ArgumentException();
                }
                x1.Re = x2.Re = -c / b;
                return Tuple.Create(x1, x2);
            }

            double d = b * b - 4 * a * c;
            if (d >= 0)
            {
                x1.Re = (-b - Math.Sqrt(d) / (2 * a));
                x2.Re = (-b + Math.Sqrt(d) / (2 * a));
            }
            else
            {
                x1.Re = x2.Re = -b / (2 * a);
                x1.Im = -(Math.Sqrt(Math.Abs(d)) / (2 * a));
                x2.Im = Math.Sqrt(Math.Abs(d)) / (2 * a);
            }

            return Tuple.Create(x1, x2);
        }
    }
}
