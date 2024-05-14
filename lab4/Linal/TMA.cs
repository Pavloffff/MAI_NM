using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Linal
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
            for (int i = 1; i < n; i++)
            {
                if (i != n - 1)
                {
                    P[i] = -A[i, i + 1] / (A[i, i] + A[i, i - 1] * P[i - 1]);
                }
                else
                {
                    P[i] = 0;
                }
                Q[i] = (b[i] - A[i, i - 1] * Q[i - 1]) / (A[i, i] + A[i, i - 1] * P[i - 1]);
            }
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