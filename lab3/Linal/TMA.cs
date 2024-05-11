using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Linal
{
    internal class TMA
    {
        public static Vector Solve(Matrix A, Vector b)
        {
            int n = A.Cols;
            Vector P = new Vector(n);
            Vector Q = new Vector(n);
            P[0] = -A[0, 1] / A[0, 0];
            Q[0] = b[0] / A[0, 0];
            for (int i = 1; i < n - 1; i++)
            {
                P[i] = -A[i, i + 1] / (A[i, i] + A[i, i - 1] * P[i - 1]);
                Q[i] = (b[i] - A[i, i - 1] * Q[i - 1]) / (A[i, i] + A[i, i - 1] * P[i - 1]);
            }
            P[n - 1] = 0;
            Q[n - 1] = (b[A.Cols - 1] - A[n - 1, n - 2] * Q[n - 2]) / (A[n - 1, n - 1] + A[n - 1, n - 2] * P[n - 2]);
            Vector x = new Vector(n);
            x[n - 1] = Q[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                x[i] = P[i] * x[i + 1] + Q[i];
            }
            return x;
        }
    }
}
