using app.Linal.Complex;
using app.Linal.Equation;
using app.Linal.Matrix;
using app.Linal.Vector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.L1.Task5
{
    internal class QR
    {
        private Matrix A;
        private readonly double epsilon;

        public QR(Matrix A, double epsilon)
        {
            this.A = A;
            this.epsilon = epsilon;
        }

        public Tuple<Matrix, Matrix> QRDecomposition(Matrix A)
        {
            int n = A.Rows;
            Matrix Q = Matrix.E(n);
            Matrix R = new Matrix(A);
            
            for (int i = 0; i < n - 1; i++)
            {
                Vector nu = new Vector(n);
                double sign = R[i, i] < 0 ? -1 : 1;
                double norm = 0;
                for (int j = i; j < n; j++)
                {
                    norm += (R[j, i] * R[j, i]);
                }
                nu[i] = R[i, i] + sign * Math.Sqrt(norm);
                for (int j = i + 1; j < n; j++)
                {
                    nu[j] = R[j, i];
                }
                Matrix H = new Matrix(n);
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        H[j, k] = (nu[j] * nu[k]);
                    }
                }
                double coef = 0;
                for (int j = 0; j < n; j++)
                {
                    coef += nu[j] * nu[j];
                }
                coef *= (-0.5);
                H.Mul(1 /  coef);
                H = Matrix.E(n) + H;
                Q *= H;
                R = H * R;
            }

            return Tuple.Create(Q, R);
        }

        public string Run()
        {
            string res = string.Empty;
            int n = A.Rows;
            Matrix prevA = A;
            int iter = 0;
            bool flag;

            List<Complex> current = new List<Complex>();
            List<Complex> prev = new List<Complex>();
            for (int i = 0; i < n; i++)
            {
                prev.Add(new Complex(0, 0));
            }

            while (true)
            {
                var QR = QRDecomposition(A);
                res += "\nMatrix Q:\n";
                res += QR.Item1.ToString();
                res += "\nMatrix R:\n";
                res += QR.Item2.ToString();
                
                A = QR.Item2 * QR.Item1;

                res += "\nMatrix A:\n";
                res += A.ToString();

                for (int i = 0; i < n; i++)
                {
                    if (i == n - 1 || Math.Abs(A[i + 1, i]) < epsilon)
                    {
                        current.Add(new Complex(A[i, i], 0));
                    }
                    else
                    {
                        double a = 1;
                        double b = (-1) * (A[i + 1, i + 1] + A[i, i]);
                        double c = A[i, i] * A[i + 1, i + 1] - A[i, i + 1] * A[i + 1, i];
                        Quadratic solverCur = new Quadratic(a, b, c);
                        var lambdas = solverCur.Solve();
                        current.Add(lambdas.Item1);
                        current.Add(lambdas.Item2);
                        i++;
                    }
                }

                flag = true;
                for (int j = 0; j < current.Count; j++)
                {
                    if (Complex.Abs(current[j] - prev[j]) > epsilon)
                    {
                        flag = false;
                    }
                }

                if (flag)
                {
                    break;
                }

                for (int j = 0; j < current.Count; j++)
                {
                    prev[j] = current[j];
                }
                current.Clear();

                iter++;
                res += "\nNumber of iteration: ";
                res += iter.ToString();
                res += "\n";
            }
            res += "\nNumber of iteration: ";
            res += iter.ToString();
            res += "\n";

            res += "\nMatrix A:\n";
            res += A.ToString();

            res += "\nEigenValues:\n";
            for (int i = 0; i < prev.Count; i++)
            {
                res += prev[i].ToString();
                res += "     ";
            }
            
            res += "\n\n\n";
            return res;
        }
    }
}
