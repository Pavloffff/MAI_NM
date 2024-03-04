using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.Linal.Matrix;
using app.Linal.Vector;

namespace app.L1.Task4
{
    internal class Rotation
    {
        private readonly Matrix A;
        private readonly double epsilon;

        public Rotation(Matrix a, double epsilon)
        {
            A = a;
            this.epsilon = epsilon;
        }

        private double t(Matrix A)
        {
            double res = 0;
            for (int i = 0; i < A.Rows - 1; i++)
            {
                for (int j = i + 1; j < A.Cols; j++)
                {
                    res += (A[i, j] * A[i, j]);
                }
            }
            return Math.Sqrt(res);
        }

        public string Run()
        {
            string res = string.Empty;
            if (!A.Equals(Matrix.T(A)))
            {
                res += "Invalid matrix\n";
                return res;
            }

            int n = A.Rows;
            int k = 0;
            
            Matrix globalU = Matrix.E(n);

            while (t(A) > epsilon)
            {
                double maxVal = 0;
                int maxI = 0, maxJ = 0;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (A[i, j] * A[i, j] > maxVal * maxVal)
                        {
                            maxVal = A[i, j];
                            maxI = i;
                            maxJ = j;
                        }
                    }
                }

                res += "\na[i, j]^(";
                res += k.ToString();
                res += ") = ";
                res += maxVal.ToString();
                res += "\n";

                Matrix U = Matrix.E(n);
                double phiK;
                
                if (A[maxI, maxI] != A[maxJ, maxJ])
                {
                    phiK = 0.5 * Math.Atan((2 * A[maxI, maxJ]) / 
                        (A[maxI, maxI] - A[maxJ, maxJ]));
                } else
                {
                    phiK = Math.PI / 4;
                }

                U[maxI, maxJ] = -Math.Sin(phiK);
                U[maxJ, maxI] = Math.Sin(phiK);
                U[maxI, maxI] = Math.Cos(phiK);
                U[maxJ, maxJ] = Math.Cos(phiK);
                
                res += "\nMatrix U^(";
                res += k.ToString();
                res += "):\n";
                res += U.ToString();

                Matrix uT = Matrix.T(U);
                Matrix nextA = ((uT * A) * U);

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        A[i, j] = nextA[i, j];
                    }
                }
                k++;

                res += "\nMatrix A^(";
                res += k.ToString();
                res += "):\n";
                res += A.ToString();

                res += "\nt(A(";
                res += k;
                res += ")) = ";
                res += t(A).ToString();
                res += t(A) > epsilon ? " > " : " < ";
                res += epsilon.ToString();
                res += "\n";
                globalU *= U;
            }

            res += "\nMatrix U:\n";
            res += globalU.ToString();

            res += "\nEigenvalues:\n";
            for (int i = 0; i < n; i++)
            {
                string value = Math.Round(A[i, i], 4).ToString("0.0000");
                value = value.PadRight(18);
                res += value;
            }

            res += "\n\nEigenvectors\n";
            for (int i = 0; i < n; i++)
            {
                res += "x";
                res += i.ToString();
                res += " = (";
                for (int j = 0; j < n; j++)
                {
                    string value = Math.Round(globalU[j, i], 4).ToString("0.0000");
                    if (j != n - 1)
                    {
                        value = value.PadRight(18);
                    }
                    res += value;
                }
                res += ")\n";
            }

            return res;
        }
    }
}
