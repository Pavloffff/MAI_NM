using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Linal
{
    internal class CubicSpline
    {
        private readonly List<Polynomial> Polynomials;
        private readonly List<double> Points;

        public CubicSpline(List<double> points, List<Polynomial> polynomials)
        {
            Polynomials = polynomials;
            Points = points;
        }

        public int Size()
        {
            return Polynomials.Count;
        }

        public double Calculate(double x)
        {
            int idx = Points.BinarySearch(x);
            if (idx < 0) idx = ~idx;
            idx = Math.Min(idx, Points.Count - 1) - 1;
            idx = Math.Max(0, idx);
            return Polynomials[idx].Calculate(x);
        }

        public override string ToString()
        {
            var res = string.Empty;
            for (int i = 0; i < Polynomials.Count; i++)
            {
                res += $"[{Points[i]}; {Points[i + 1]}] {Polynomials[i]}\n";
            }
            return res;
        }
    }
}
