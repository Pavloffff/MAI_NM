using app.Linal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.L3
{
    internal class Task3
    {
        private readonly List<double> X;
        private readonly List<double> fX;
        
        public Task3(List<double> x, List<double> y)
        {
            X = x;
            fX = y;
        }

        private static string Str(double value)
        {
            return Math.Round(value, 4).ToString("0.0000");
        }

        private static string PrintString(string i, string xi, string Fxi)
        {
            int pad = 20;
            string res = string.Empty;
            string value = i;
            value = value.PadRight(pad);
            res += value;
            value = xi;
            value = value.PadRight(pad);
            res += value;
            value = Fxi;
            value = value.PadRight(pad);
            res += value;
            res += "\n";
            return res;
        }

        public (string, Polynomial) Run(int pow)
        {
            string res = string.Empty;
            res += $"LSM with pow = {pow - 1}:\n\n";
            int n = X.Count;
            Matrix Phi = new Matrix(n, pow);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < pow; j++)
                {
                    Phi[i, j] = Math.Pow(X[i], j);
                }
            }
            Matrix PhiT = Matrix.T(Phi);
            Matrix G = PhiT * Phi;
            Vector Y = new Vector(fX);
            Vector Z = PhiT * Y;
            Vector ansV = Gauss.Solve(G, Z);
            List<double> ansL = new List<double>(new double[ansV.Rows]);
            for (int i = 0; i < ansL.Count; i++)
            {
                ansL[i] = ansV[i];
            }

            for (int i = 0; i < ansL.Count; i++)
            {
                res += $"a{i} = {ansL[i]} \n";
            }
            
            res += "\n";
            var poly = new Polynomial(ansL);
            double MSE = 0;
            res += PrintString("i", "xi", $"F{pow - 1}(xi)");
            res += "\n";
            for (int i = 0; i < n; i++)
            {
                double FpowXj = poly.Calculate(X[i]);
                res += PrintString(i.ToString(), Str(X[i]), Str(FpowXj));
                MSE += (FpowXj - fX[i]) * (FpowXj - fX[i]);
            }
            res += "\n";
            res += poly.ToString();
            res += $"\n\nФ = {MSE}\n\n";
            
            return (res, poly);
        }
    }
}
