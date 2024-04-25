using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Linal
{
    internal class Gauss
    {
        public static Vector Solve(Matrix A, Vector  b)
        {
            int n = A.Cols;
            Matrix.LU(A);
            for (int i = 0; i < A._swapped.Count; i++)
            {
                b[A._swapped[i].Item1] += b[A._swapped[i].Item2];
                b[A._swapped[i].Item2] = b[A._swapped[i].Item1] - b[A._swapped[i].Item2];
                b[A._swapped[i].Item1] -= b[A._swapped[i].Item2];
            }
            Vector z = new Vector(n);
            z[0] = b[0];
            for (int i = 1; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < i; j++)
                {
                    sum += z[j] * Matrix.GetL(A, i, j);
                }
                z[i] = b[i] - sum;
            }
            Vector x = new Vector(n);
            x[n - 1] = z[n - 1] / Matrix.GetU(A, n - 1, n - 1);
            for (int i = n - 2; i >= 0; i--)
            {
                double sum = 0;
                for (int j = i + 1; j < n; j++)
                {
                    sum += x[j] * Matrix.GetU(A, i, j);
                }
                x[i] = (1 / Matrix.GetU(A, i, i)) * (z[i] - sum);
            }
            return x;
        }
    }
}
