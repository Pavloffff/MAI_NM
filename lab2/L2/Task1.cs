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

        private string Str(double value)
        {
            return Math.Round(value, 4).ToString("0.0000");
        }

        private string PrintStringNewton(string k, string xk, string fxk, string dfxk, string fxkdfxk)
        {
            string res = string.Empty;
            string value = k;
            value = value.PadRight(pad);
            res += value;
            value = xk;
            value = value.PadRight(pad);
            res += value;
            value = fxk;
            value = value.PadRight(pad);
            res += value;
            value = dfxk;
            value = value.PadRight(pad);
            res += value;
            value = fxkdfxk;
            value = value.PadRight(pad);
            res += value;
            res += "\n";
            return res;
        }

        private string PrintStringIterations(string k, string xk, string fxk)
        {
            string res = string.Empty;
            string value = k;
            value = value.PadRight(pad);
            res += value;
            value = xk;
            value = value.PadRight(pad);
            res += value;
            value = fxk;
            value = value.PadRight(pad);
            res += value;
            res += "\n";
            return res;
        }

        public string Newton()
        {
            string res = string.Empty;  // проверить условие на 2 странице внизу
            double xk = right;
            double prevXk = xk;
            int iter = 0;

            res += "Newton Method:\n\n";
            res += PrintStringNewton("k", "x(k)", "f(x(k))", "df(x(k))", "f(x(k))/df(x(k))");
            res += "\n";

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

                res += PrintStringNewton(iter.ToString(), Str(xk), Str(fxk), Str(dfxk), Str(-(fxk / dfxk)));
                xk = prevXk - (fxk / dfxk);

                if (Math.Abs(prevXk - xk) < epsilon)
                {
                    break;
                }

                prevXk = xk;
                iter++;
            }

            res += "\nAnswer: ";
            res += xk;
            res += "\n";

            return res;
        }

        public string Iterations()
        {
            string res = string.Empty;
            //int prec = BitConverter.GetBytes(decimal.GetBits((decimal)epsilon)[3])[2]; если 2 производная знакопостоянна это работает, иначе дихотомии

            double l = left, r = right, step = 1.0 / 3;
            double fLeft, fLeftRight, dfLeft, fRight, fRightLeft, dfRight;
            fLeft = solver.Solve(functionTokens, left, 0, a);
            fLeftRight = solver.Solve(functionTokens, left + epsilon, 0, a);
            dfLeft = (fLeftRight - fLeft) / epsilon;

            fRight = solver.Solve(functionTokens, right, 0, a);
            fRightLeft = solver.Solve(functionTokens, right - epsilon, 0, a);
            dfRight = (fRight - fRightLeft) / epsilon;
            while (Math.Abs(l - r) > epsilon)
            {
                double lk = l + step * (r - l);
                double rk = r - step * (r - l);
                fLeft = solver.Solve(functionTokens, lk, 0, a);
                fLeftRight = solver.Solve(functionTokens, lk + epsilon, 0, a);
                dfLeft = (fLeftRight - fLeft) / epsilon;

                fRight = solver.Solve(functionTokens, rk, 0, a);
                fRightLeft = solver.Solve(functionTokens, rk - epsilon, 0, a);
                dfRight = (fRight - fRightLeft) / epsilon;

                if (Math.Abs(dfLeft) < Math.Abs(dfRight))
                {
                    l = lk;
                }
                else
                {
                    r = rk;
                }
            }
            double maxAbsdfxIdx = (l + r) / 2;
            fLeft = solver.Solve(functionTokens, maxAbsdfxIdx, 0, a);
            fLeftRight = solver.Solve(functionTokens, maxAbsdfxIdx + epsilon, 0, a);
            dfLeft = (fLeftRight - fLeft) / epsilon;

            int sign = dfRight >= 0 ? 1 : -1;
            double lambda = sign / dfLeft;

            l = left;
            r = right;
            double q = 1;
            while (Math.Abs(l - r) > epsilon)
            {
                double lk = l + step * (r - l);
                double rk = r - step * (r - l);
                fLeft = solver.Solve(functionTokens, lk, 0, a);
                fLeftRight = solver.Solve(functionTokens, lk + epsilon, 0, a);
                dfLeft = (fLeftRight - fLeft) / epsilon;
                double q1 = 1 - lambda * dfLeft;

                fRight = solver.Solve(functionTokens, rk, 0, a);
                fRightLeft = solver.Solve(functionTokens, rk - epsilon, 0, a);
                dfRight = (fRight - fRightLeft) / epsilon;
                double q2 = 1 - lambda * dfRight;

                if (q1 < q2)
                {
                    l = lk;
                }
                else
                {
                    r = rk;
                }
            }
            double maxQIdx = (r + l) / 2;
            fLeft = solver.Solve(functionTokens, maxQIdx, 0, a);
            fLeftRight = solver.Solve(functionTokens, maxQIdx + epsilon, 0, a);
            dfLeft = (fLeftRight - fLeft) / epsilon;
            q = 1 - lambda * dfLeft;

            res += "Iterations Method:\n\n";

            res += "lambda = ";
            res += lambda.ToString();
            res += "\n";
            res += "q = ";
            res += q.ToString();
            res += "\n\n";
            res += PrintStringIterations("k", "xk", "f(xk)");
            res += "\n";

            int iter = 0;
            double xk = (left + right) / 2;
            double prevXk = xk;

            while (true)
            {
                if (iter > iterations)
                {
                    break;
                }
                res += PrintStringIterations(
                    iter.ToString(), Str(xk), Str(solver.Solve(functionTokens, xk, 0, a)));

                xk = prevXk - lambda * solver.Solve(functionTokens, prevXk, 0, a);


                if ((q / (1 - q)) * Math.Abs(xk - prevXk) <= epsilon)
                {
                    res += PrintStringIterations(
                        "ok", Str(xk), Str(solver.Solve(functionTokens, xk, 0, a)));
                    break;
                }

                prevXk = xk;
                iter++;
            }

            res += "\nAnswer: ";
            res += xk;
            res += "\n";

            return res;
        }
    }
}
