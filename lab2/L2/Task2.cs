using app.Equation;
using app.Linal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.L2
{
    internal class Task2
    {
        private readonly int pad = 20;
        private readonly List<Token> equation1Tokens;
        private readonly List<Token> function1Tokens;
        private readonly List<Token> equation2Tokens;
        private readonly List<Token> function2Tokens;
        private readonly double leftX;
        private readonly double rightX;
        private readonly double leftY;
        private readonly double rightY;
        private readonly double a;
        private readonly double epsilon;
        private readonly int iterations;
        private readonly Lexer lexer;
        private readonly Parser parser;
        private readonly Solver solver;

        public Task2(string equation1, string equation2,
            double leftX, double rightX, double leftY, double rightY,
            double a, double epsilon, int iterations)
        {
            lexer = new Lexer();
            parser = new Parser();
            solver = new Solver();
            equation1Tokens = lexer.Run(equation1);
            equation1Tokens = parser.ToPostfix(equation1Tokens);
            function1Tokens = new List<Token>(equation1Tokens);
            function1Tokens.RemoveAt(equation1Tokens.Count - 1);
            function1Tokens.RemoveAt(equation1Tokens.Count - 2);
            equation2Tokens = lexer.Run(equation2);
            equation2Tokens = parser.ToPostfix(equation2Tokens);
            function2Tokens = new List<Token>(equation2Tokens);
            function2Tokens.RemoveAt(equation2Tokens.Count - 1);
            function2Tokens.RemoveAt(equation2Tokens.Count - 2);
            this.leftX = leftX;
            this.rightX = rightX;
            this.leftY = leftY;
            this.rightY = rightY;
            this.a = a;
            this.epsilon = epsilon;
            this.iterations = iterations;
        }

        public string Newton()
        {
            string res = string.Empty;
            res += "Newton Method:\n\n";
            string value = "k";
            value = value.PadRight(pad);
            res += value;
            value = "x1(k)";
            value = value.PadRight(pad);
            res += value;
            value = "f1(x1, x2)";
            value = value.PadRight(pad);
            res += value;
            value = "df1dx1";
            value = value.PadRight(pad);
            res += value;
            value = "df1dx2";
            value = value.PadRight(pad);
            res += value;
            value = "det(A1)";
            value = value.PadRight(pad);
            res += value;
            value = "det(A2)";
            value = value.PadRight(pad);
            res += value;
            value = "det(J)";
            value = value.PadRight(pad);
            res += value;
            res += "\n";
            value = string.Empty;
            value = value.PadRight(pad + 1);
            res += value;
            value = "x2(k)";
            value = value.PadRight(pad);
            res += value;
            value = "f2(x1, x2)";
            value = value.PadRight(pad);
            res += value;
            value = "df2dx1";
            value = value.PadRight(pad);
            res += value;
            value = "df2dx2";
            value = value.PadRight(pad);
            res += value;
            res += "\n\n";

            double xk = (leftX + rightX) / 2;
            double yk = (leftY + rightY) / 2;
            double prevxk = xk, prevyk = yk;

            int iter = 0;
            while (iter < iterations)
            {
                double f1 = solver.Solve(function1Tokens, xk, yk, a);
                double f1rightX = solver.Solve(function1Tokens, xk + epsilon, yk, a);
                double df1dx = (f1rightX - f1) / epsilon;
                double f1rightY = solver.Solve(function1Tokens, xk, yk + epsilon, a);
                double df1dy = (f1rightY - f1) / epsilon;

                double f2 = solver.Solve(function2Tokens, xk, yk, a);
                double f2rightX = solver.Solve(function2Tokens, xk + epsilon, yk, a);
                double df2dx = (f2rightX - f2) / epsilon;
                double f2rightY = solver.Solve(function2Tokens, xk, yk + epsilon, a);
                double df2dy = (f2rightY - f2) / epsilon;

                Matrix Jk = new Matrix(2);
                Jk[0, 0] = df1dx;
                Jk[0, 1] = df1dy;
                Jk[1, 0] = df2dx;
                Jk[1, 1] = df2dy;
                double detJk = Jk[0, 0] * Jk[1, 1] - Jk[0, 1] * Jk[1, 0];

                Matrix A1k = new Matrix(2);
                A1k[0, 0] = f1;
                A1k[0, 1] = df1dy;
                A1k[1, 0] = f2;
                A1k[1, 1] = df2dy;
                double detA1k = A1k[0, 0] * A1k[1, 1] - A1k[0, 1] * A1k[1, 0];


                Matrix A2k = new Matrix(2);
                A2k[0, 0] = df1dx;
                A2k[0, 1] = df2dx;
                A2k[1, 0] = f1;
                A2k[1, 1] = f2;
                double detA2k = A2k[0, 0] * A2k[1, 1] - A2k[0, 1] * A2k[1, 0];
                
                value = iter.ToString();
                value = value.PadRight(pad);
                res += value;
                value = Math.Round(xk, 4).ToString("0.0000");
                value = value.PadRight(pad);
                res += value;
                value = Math.Round(f1, 4).ToString("0.0000");
                value = value.PadRight(pad);
                res += value;
                value = Math.Round(df1dx, 4).ToString("0.0000");
                value = value.PadRight(pad);
                res += value;
                value = Math.Round(df1dy, 4).ToString("0.0000");
                value = value.PadRight(pad);
                res += value;
                value = Math.Round(detA1k, 4).ToString("0.0000");
                value = value.PadRight(pad);
                res += value;
                value = Math.Round(detA2k, 4).ToString("0.0000");
                value = value.PadRight(pad);
                res += value;
                value = Math.Round(detJk, 4).ToString("0.0000");
                value = value.PadRight(pad);
                res += value;
                res += "\n";
                value = string.Empty;
                value = value.PadRight(pad + 1);
                res += value;
                value = Math.Round(yk, 4).ToString("0.0000");
                value = value.PadRight(pad);
                res += value;
                value = Math.Round(f2, 4).ToString("0.0000");
                value = value.PadRight(pad);
                res += value;
                value = Math.Round(df2dx, 4).ToString("0.0000");
                value = value.PadRight(pad);
                res += value;
                value = Math.Round(df2dy, 4).ToString("0.0000");
                value = value.PadRight(pad);
                res += value;
                res += "\n";

                xk -= detA1k / detJk;
                yk -= detA2k / detJk;

                if (Math.Max(Math.Abs(xk - prevxk), Math.Abs(prevyk - yk)) <= epsilon)
                {
                    break;
                }

                prevxk = xk;
                prevyk = yk;
                iter++;
            }

            res += "Answer: ";

            res += Math.Round(xk, 4).ToString("0.0000");
            res += "     ";
            res += Math.Round(yk, 4).ToString("0.0000");

            return res;
        }
    }
}
