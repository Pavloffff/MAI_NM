using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Linal.Complex
{
    internal class Complex
    {
        public double Re;
        public double Im;

        public Complex()
        {
            Re = 0;
            Im = 0;
        }

        public Complex(Complex other)
        {
            Re = other.Re;
            Im = other.Im;
        }

        public Complex(double Re, double Im)
        {
            this.Re = Re;
            this.Im = Im;
        }

        public static Complex operator +(Complex a, Complex b)
        {
            Complex res = new Complex(a);
            res.Re += b.Re;
            res.Im += b.Im;
            return res;
        }

        public static Complex operator *(Complex a, double c)
        {
            Complex res = new Complex(a);
            res.Re *= c;
            res.Im *= c;
            return res;
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return (a + (b * (-1)));
        }

        public static double Abs(Complex x)
        {
            return Math.Sqrt(x.Re * x.Re + x.Im * x.Im);
        }

        public override string ToString()
        {
            string sign = Im >= 0 ? "+" : "-";
            string res = $"{Math.Round(Re, 4)} {sign} {Math.Abs(Math.Round(Im, 4))}i";
            return res;
        }
    }
}
