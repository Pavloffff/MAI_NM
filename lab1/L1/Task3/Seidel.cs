using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.Linal.Vector;
using app.Linal.Matrix;

namespace app.L1.Task3
{
    internal class Seidel
    {
        private readonly Matrix B;
        private readonly Matrix C;
        private readonly Matrix alpha;
        private readonly Vector beta;
        private readonly Vector gamma;
        private readonly double epsilon;

        public Seidel(Matrix A, Vector b, double epsilon)
        {
            int n = A.Rows;
            B = new Matrix(n);
            C = new Matrix(n);
            beta = new Vector(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        if (i > j)
                        {
                            B[i, j] = -(A[i, j] / A[i, i]);
                        }
                        else
                        {
                            C[i, j] = -(A[i, j] / A[i, i]);
                        }
                    }
                }
                beta[i] = b[i] / A[i, i];
            }
            B.Mul(-1);
            alpha = (Matrix.Inverse((Matrix.E(n) + B)) * C);
            gamma = (Matrix.Inverse((Matrix.E(n) + B)) * beta);
            B.Mul(-1);
            this.epsilon = epsilon;
        }

        public string Run()
        {
            bool cond = true;
            string res = string.Empty;
            int n = B.Rows;

            res += "\nMatrix B:\n";
            res += B.ToString();
            res += "\nMatrix C:\n";
            res += C.ToString();
            res += "\nMatrix alpha = (E - B)^(-1)C:\n";
            res += alpha.ToString();
            res += "\nVector beta:\n";
            res += beta.ToString();
            res += "\n\nVector gamma = (E - B)^(-1)beta:\n";
            res += gamma.ToString();

            //double normAlpha = Matrix.Plus(B, C).Norm();
            double normAlpha = alpha.Norm();
            res += "\n\n||alpha|| = ";
            res += normAlpha.ToString();
            res += "\n";

            if (normAlpha >= 1)
            {
                cond = false;
                res += "The sufficient convergence condition is not met!\n";
            }
            else
            {
                res += "\nThe sufficient convergence condition is satisfied\n";
            }

            res += "\nEpsilon = ";
            res += epsilon.ToString();
            res += "\n";
            double epsilonK = epsilon + 1; 

            Vector x = new Vector(beta);
            Vector prevX = new Vector(beta);
            int k = 0;
            
            res += "\n";

            while (epsilonK > epsilon)
            {
                x = (gamma + (alpha * prevX));
                double coef = C.Norm() / (1 - alpha.Norm());
                double normDiffXk = (x + (prevX * (-1))).Norm();
                if (cond)
                {
                    epsilonK = coef * normDiffXk;
                }
                else
                {
                    epsilonK = normDiffXk;
                }
                k++;

                res += "x^(";
                res += k.ToString();
                res += ") = (";

                for (int i = 0; i < n; i++)
                {
                    prevX[i] = x[i];
                    
                    string value = Math.Round(x[i], 3).ToString("0.000");
                    if (i < n - 1)
                    {
                        value = value.PadRight(15);
                    }
                    res += value;
                }

                res += ")^T, epsilon^(";
                res += k.ToString();
                res += ") = ";
                res += epsilonK;
                res += epsilonK > epsilon ? " > " : " < ";
                res += epsilon.ToString();
                res += "\n";
            }

            res += "\nVector x (answer):\n";
            res += x.ToString();

            res += "\n\nNumber of iterations: ";
            res += k.ToString();
            res += "\n\nA priori estimate of the number of iterations: K + 1 >= ";
            double estK = (Math.Log10(epsilon) - Math.Log10(gamma.Norm()) + 
                Math.Log10(1 - alpha.Norm())) / Math.Log10(alpha.Norm());
            res += estK.ToString();
            res += "\n";
            return res;
        }
    }
}
