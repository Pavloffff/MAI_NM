using app.Equation;
using app.Matan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.L2
{
    internal class Task1
    {
        private readonly int pad = 20;
        private readonly List<Token> equationTokens;
        private readonly List<Token> functionTokens;
        private readonly double left;
        private readonly double right;
        private readonly double a;
        private readonly double epsilon;
        private readonly int iterations;
        private readonly Lexer lexer;
        private readonly Parser parser;
        private readonly Solver solver;

        public Task1(string equation,
            double left, double right, double a, double epsilon, int iterations)
        {
            lexer = new Lexer();
            parser = new Parser();
            solver = new Solver();
            equationTokens = lexer.Run(equation);
            equationTokens = parser.ToPostfix(equationTokens);
            functionTokens = new List<Token>(equationTokens);
            functionTokens.RemoveAt(equationTokens.Count - 1);
            functionTokens.RemoveAt(equationTokens.Count - 2);
            this.left = left;
            this.right = right;
            this.a = a;
            this.epsilon = epsilon;
            this.iterations = iterations;
        }

        public string Newton()
        {
            string res = string.Empty;
            double xk = right;
            double prevXk = xk;
            int iter = 0;

            res += "Newton Method:\n\n";
            string value = "k";
            value = value.PadRight(pad);
            res += value;
            value = "x(k)";
            value = value.PadRight(pad);
            res += value;
            value = "f(x(k))";
            value = value.PadRight(pad);
            res += value;
            value = "df(x(k))";
            value = value.PadRight(pad);
            res += value;
            value = "f(x(k))/df(x(k))";
            value = value.PadRight(pad);
            res += value;
            res += "\n\n";

            while (true)
            {
                if (iter > iterations)
                {
                    break;
                }

                double fxk = solver.Solve(functionTokens, xk, 0, a);

                double fxkLeft = solver.Solve(functionTokens, xk - epsilon, 0, a);
                //double fxkRight = solver.Solve(functionTokens, xk + epsilon, a);

                //double dfxk = (fxk - fxkLeft) / (xk - (xk - epsilon)) +
                //        ((fxkRight - fxk) / ((xk + epsilon) - xk) - (fxk - fxkLeft) / 
                //        (xk - (xk + epsilon))) / ((xk + epsilon) - (xk - epsilon)) * (2 * xk - (xk - epsilon) - (xk + epsilon));
                double dfxk = (fxk - fxkLeft) / (epsilon);

                value = iter.ToString();
                value = value.PadRight(pad);
                res += value;
                value = Math.Round(xk, 4).ToString("0.0000");
                value = value.PadRight(pad);
                res += value;
                value = Math.Round(fxk, 4).ToString("0.0000");
                value = value.PadRight(pad);
                res += value;
                value = Math.Round(dfxk, 4).ToString("0.0000");
                value = value.PadRight(pad);
                res += value;
                value = Math.Round(-(fxk / dfxk), 4).ToString("0.0000");
                value = value.PadRight(pad);
                res += value;
                res += "\n";

                xk = prevXk - (fxk / dfxk);

                if (Math.Abs(prevXk - xk) < epsilon)
                {
                    break;
                }

                prevXk = xk;
                iter++;
            }

            res += "\nAnswer: ";
            res += Math.Round(xk, 4).ToString("0.0000");
            res += "\n";

            return res;
        }

        public string Iterations()
        {
            string res = string.Empty;
            //int prec = BitConverter.GetBytes(decimal.GetBits((decimal)epsilon)[3])[2];
            double m = Int32.MaxValue, M = Int32.MinValue;

            for (double i = left; i <= right; i += epsilon)
            {
                double fi = solver.Solve(functionTokens, i, 0, a);
                double fiRight = solver.Solve(functionTokens, i + epsilon, 0, a);
                double df = (fiRight - fi) / epsilon;
                if (df < m)
                {
                    m = df;
                }
                if (df > M)
                {
                    M = df;
                }
            }

            res += "Iterations Method:\n\n";

            double lambda = 2 / (M + m), q = Math.Abs((M - m) / (M + m));
            res += "lambda = ";
            res += lambda.ToString();
            res += "\n";
            res += "q = ";
            res += q.ToString();
            res += "\n\n";

            string value = "k";
            value = value.PadRight(pad);
            res += value;
            value = "x(k)";
            value = value.PadRight(pad);
            res += value;
            value = "f(x(k))";
            value = value.PadRight(pad);
            res += value;
            res += "\n\n";

            int iter = 0;
            double xk = (left + right) / 2;
            double prevXk = xk;

            // https://dxdy.ru/topic22993.html
            while (true)
            {
                if (iter > iterations)
                {
                    break;
                }
                value = iter.ToString();
                value = value.PadRight(pad);
                res += value;
                value = Math.Round(xk, 4).ToString("0.0000");
                value = value.PadRight(pad);
                res += value;
                value = Math.Round(solver.Solve(functionTokens, xk, 0, a), 4).ToString("0.0000");
                value = value.PadRight(pad);
                res += value;
                res += "\n";

                xk = prevXk - lambda * solver.Solve(functionTokens, prevXk, 0, a);


                if (Math.Abs(xk - prevXk) <= ((1 - q) / q) * epsilon)
                {
                    value = "ok";
                    value = value.PadRight(pad);
                    res += value;
                    value = Math.Round(xk, 4).ToString("0.0000");
                    value = value.PadRight(pad);
                    res += value;
                    value = Math.Round(solver.Solve(functionTokens, xk, 0, a), 4).ToString("0.0000");
                    value = value.PadRight(pad);
                    res += value;
                    res += "\n";
                    break;
                }

                prevXk = xk;
                iter++;
            }

            res += "\nAnswer: ";
            res += Math.Round(xk, 4).ToString("0.0000");
            res += "\n";

            return res;
        }
    }
}
