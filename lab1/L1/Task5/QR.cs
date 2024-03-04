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

                bool flag = true;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (Math.Abs(A[j, i]) > epsilon)
                        {
                            res += $"\n{Math.Abs(A[j, i])}    {epsilon}\n";
                            flag = false;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        Quadratic solverCur = new Quadratic(1, (-1) * (A[i + 1, i + 1] + A[i, i]), 
                            A[i, i] * A[i + 1, i + 1] - A[i, i + 1] * A[i + 1, i]);
                        var lambdaCur = solverCur.Solve();
                        
                        

                        res += $"\nBlock:\n{A[i, i]}    {A[i, i + 1]}\n";
                        res += $"{A[i + 1, i]}    {A[i + 1, i + 1]}\n";
                        res += "\nlambda^(";
                        res += iter.ToString();
                        res += "):\n";
                        res += lambdaCur.Item1.ToString();
                        res += "     ";
                        res += lambdaCur.Item2.ToString();
                        res += "\n";

                        Quadratic solverPrev = new Quadratic(1, (-1) * (prevA[i + 1, i + 1] + prevA[i, i]), 
                            prevA[i, i] * prevA[i + 1, i + 1] - prevA[i, i + 1] * prevA[i + 1, i]);
                        var lambdaPrev = solverPrev.Solve();

                        res += "\nlambda^(";
                        res += (iter - 1).ToString();
                        res += "):\n";
                        res += lambdaPrev.Item1.ToString();
                        res += "     ";
                        res += lambdaPrev.Item2.ToString();
                        res += "\n";
                        res += Complex.Abs(lambdaCur.Item1 - lambdaPrev.Item1);
                        res += "    ";
                        res += Complex.Abs(lambdaCur.Item2 - lambdaPrev.Item2);
                        res += "\n";

                        if (Complex.Abs(lambdaCur.Item1 - lambdaPrev.Item1) < epsilon &&
                            Complex.Abs(lambdaCur.Item2 - lambdaPrev.Item2) < epsilon)
                        {
                            flag = true;
                            i++;
                        }
                        else
                        {
                            break;
                        }
                        //if (Math.Abs(A[i, i + 1] * A[i + 1, i] - 
                        //    prevA[i, i + 1] * prevA[i + 1, i]) < epsilon)
                        //{
                        //    flag = true;
                        //    i++;
                        //}
                        //else
                        //{
                        //    break;
                        //}
                    }
                }

                res += flag.ToString();
                res += "\n";

                if (flag)
                {
                    break;
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        prevA[i, j] = A[i, j];
                    }
                }
                if (iter > 10)
                {
                    break;
                }
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

            bool endFlag = true;

            res += "\nEigenValues:\n";
            for (int i = 0; i < n - 1; i++)
            {
                endFlag = true;
                for (int j = i + 1; j < n; j++)
                {
                    if (A[i, j] > epsilon)
                    {
                        endFlag = false;
                        break;
                    }
                }
                if (!endFlag)
                {
                    Quadratic solver = new Quadratic(1, (-1) * (A[i + 1, i + 1] + A[i, i]), 
                            A[i, i] * A[i + 1, i + 1] - A[i, i + 1] * A[i + 1, i]);
                    var complexPair = solver.Solve();
                    res += complexPair.Item1;
                    res += "    ";
                    res += complexPair.Item2;
                    res += "    ";
                    i++;
                }
                else
                {
                    res += Math.Round(A[i, i], 4);
                    res += "    ";
                }
            }
            if (endFlag)
            {
                res += Math.Round(A[n - 1, n - 1], 4);
                res += "    ";
            }
            res += "\n";
            return res;
        }
    }
}
