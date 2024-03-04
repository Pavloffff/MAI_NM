using app.Linal.Matrix;
using app.Linal.Vector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.L1.Task3
{
    internal class Iteration
    {
        private readonly Matrix alpha;
        private readonly Vector beta;
        private readonly double epsilon;

        public Iteration(Matrix A, Vector b, double epsilon)
        {
            int n = A.Rows;
            alpha = new Matrix(n);
            beta = new Vector(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        alpha[i, j] = -(A[i, j] / A[i, i]);
                    }
                }
                beta[i] = b[i] / A[i, i];
            }
            this.epsilon = epsilon;
        }

        public string Run()
        {
            bool cond = true;

            double estK = (Math.Log10(epsilon) - Math.Log10(beta.Norm()) + 
                Math.Log10(1 - alpha.Norm())) / Math.Log10(alpha.Norm());

            string res = string.Empty;
            int n = alpha.Rows;

            res += "\nMatrix alpha:\n";
            res += alpha.ToString();
            res += "\nVector beta:\n";
            res += beta.ToString();

            res += "\n\n||alpha|| = ";
            res += alpha.Norm().ToString();
            res += "\n";

            if (alpha.Norm() >= 1)
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
                x = (beta + (alpha * prevX));
                double coef = Math.Pow(alpha.Norm(), k) / (1 - alpha.Norm());
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
                if (k > estK)
                {
                    break;
                }
                
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
            res += estK.ToString();
            res += "\n";
            return res;
        }
    }
}
