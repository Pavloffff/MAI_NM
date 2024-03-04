using app.Linal.Matrix;
using app.Linal.Vector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.L1.Task1
{
    internal class LU
    {
        private readonly Matrix A;
        private readonly Vector b;

        public LU(Matrix a, Vector b)
        {
            A = a;
            this.b = b;
        }

        public string Run()
        {
            string res = string.Empty;
            res += "\nDet(A):\n";
            res += Math.Round(A.Determinant(), 3).ToString("0.000");
            res += "\n\nA^(-1):\n";
            Matrix inv = Matrix.Inverse(A);
            for (int i = 0; i < inv.Rows; i++)
            {
                for (int j = 0; j < inv.Cols; j++)
                {
                    string value =  Math.Round(inv[i, j], 3).ToString("0.000");
                    value = value.PadRight(15);
                    res += value;
                }
                res += "\n";
            }
            Matrix.LU(A);
            for (int i = 0; i < A._swapped.Count; i++)
            {
                b[A._swapped[i].Item1] += b[A._swapped[i].Item2];
                b[A._swapped[i].Item2] = b[A._swapped[i].Item1] - b[A._swapped[i].Item2];
                b[A._swapped[i].Item1] -= b[A._swapped[i].Item2];
            }
            res += "\nMatrix L:\n";
            for (int i = 0; i < inv.Rows; i++)
            {
                for (int j = 0; j < inv.Cols; j++)
                {
                    string value = Math.Round(Matrix.GetL(A, i, j), 4).ToString("0.0000");
                    value = value.PadRight(18);
                    res += value;
                }
                res += "\n";
            }
            res += "\nMatrix U:\n";
            for (int i = 0; i < inv.Rows; i++)
            {
                for (int j = 0; j < inv.Cols; j++)
                {
                    string value = Math.Round(Matrix.GetU(A, i, j), 4).ToString("0.0000");
                    value = value.PadRight(18);
                    res += value;
                }
                res += "\n";
            }
            Vector z = new Vector(inv.Cols);
            z[0] = b[0];
            for (int i = 1; i < inv.Rows; i++)
            {
                double sum = 0;
                for (int j = 0; j < i; j++)
                {
                    sum += z[j] * Matrix.GetL(A, i, j);
                }
                z[i] = b[i] - sum;
            }
            res += "\nVector z:\n";
            res += z.ToString();
            res += "\n";
            Vector x = new Vector(inv.Cols);
            x[inv.Rows - 1] = z[inv.Cols - 1] / Matrix.GetU(A, inv.Rows - 1, inv.Cols - 1);
            for (int i = inv.Cols - 2; i >= 0; i--)
            {
                double sum = 0;
                for (int j = i + 1; j < inv.Cols; j++)
                {
                    sum += x[j] * Matrix.GetU(A, i, j);
                }
                x[i] = (1 / Matrix.GetU(A, i, i)) * (z[i] - sum);
            }
            res += "\nVector x (answer):\n";
            res += x.ToString();
            res += "\n";
            return res;
        }        
    }
}
