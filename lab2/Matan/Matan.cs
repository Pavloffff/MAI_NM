using app.Equation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Matan
{
    internal class Matan
    {
        public Matan() { }

        //public List<double> Run(List<double> f, List<double> x)
        //{
        //    List<double> df = new List<double>(f);
        //    if (f.Count < 2)
        //    {
        //        df[0] = f[0];
        //    }
        //    if (f.Count == 2)
        //    {
        //        df[1] = df[0] = (f[1] - f[0]) / (x[1] - x[0]);
        //    }
        //    else
        //    {
        //        for (int i = 1; i < f.Count - 1; i++)
        //        {
        //            df[i] = (f[i] - f[i - 1]) / (x[i] - x[i - 1]) +
        //                (((f[i + 1] - f[i]) / (x[i + 1] - x[i]) - (f[i] - f[i - 1]) / 
        //                (x[i] - x[i + 1])) / (x[i + 1] - x[i - 1])) * (2 * x[i] - x[i - 1] - x[i + 1]);
        //        }
        //        df[0] = df[1];
        //        df[df.Count - 1] = df[df.Count - 2];
        //    }
        //    return df;
        //}

        public double Q(List<Token> f, double x, double a, double epsilon, double lambda)
        {
            return (1 - lambda * DfLeft(f, x, a, epsilon));
        }

        public double DfLeftAbs(List<Token> f, double x, double a, double epsilon, double lambda)
        {
            return Math.Abs(DfLeft(f, x, a, epsilon));
        }

        public double DfLeft(List<Token> f, double x, double a, double epsilon)
        {
            Solver solver = new Solver();
            double fLeft = solver.Solve(f, x, 0, a);
            double fLeftRight = solver.Solve(f, x + epsilon, 0, a);
            return (fLeftRight - fLeft) / epsilon;
        }

        public double DfRight(List<Token> f, double x, double a, double epsilon)
        {
            Solver solver = new Solver();
            double fRight = solver.Solve(f, x, 0, a);
            double fRightLeft = solver.Solve(f, x - epsilon, 0, a);
            return (fRight - fRightLeft) / epsilon;
        }
    }
}
