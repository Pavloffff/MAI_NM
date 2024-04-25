using app.Equation;
using app.Linal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        private string Str(double value)
        {
            return Math.Round(value, 4).ToString("0.0000");
        }

        private string PrintStringNewton(
            string k, string x1k, string f1, string df1dx1,
            string df1dx2, string detA1, string detA2, string detJ,
            string x2k, string f2, string df2dx1, string df2dx2)
        {
            string res = string.Empty;
            string value = k;
            value = value.PadRight(pad);
            res += value;
            value = x1k;
            value = value.PadRight(pad);
            res += value;
            value = f1;
            value = value.PadRight(pad);
            res += value;
            value = df1dx1;
            value = value.PadRight(pad);
            res += value;
            value = df1dx2;
            value = value.PadRight(pad);
            res += value;
            value = detA1;
            value = value.PadRight(pad);
            res += value;
            value = detA2;
            value = value.PadRight(pad);
            res += value;
            value = detJ;
            value = value.PadRight(pad);
            res += value;
            res += "\n";
            value = string.Empty;
            value = value.PadRight(pad + 1);
            res += value;
            value = x2k;
            value = value.PadRight(pad);
            res += value;
            value = f2;
            value = value.PadRight(pad);
            res += value;
            value = df2dx2;
            value = value.PadRight(pad);
            res += value;
            res += "\n";
            return res;
        }

        private string PrintStringIterations(
            string k, string x1k, string f1, string x2k, string f2)
        {
            string res = string.Empty;
            string value = k;
            value = value.PadRight(pad);
            res += value;
            value = x1k;
            value = value.PadRight(pad);
            res += value;
            value = f1;
            value = value.PadRight(pad);
            res += value;
            res += "\n";
            value = string.Empty;
            value = value.PadRight(pad + 1);
            res += value;
            value = x2k;
            value = value.PadRight(pad);
            res += value;
            value = f2;
            value = value.PadRight(pad);
            res += value;
            res += "\n";
            return res;
        }

        public string Newton()
        {
            string res = string.Empty;
            res += "Newton Method:\n\n";
            res += PrintStringNewton(
                "k", "x1(k)", "f1(x1, x2)", "df1dx1", "df1dx2",
                "det(A1)", "det(A2)", "det(J)", "x2(k)", "f2(x1, x2)",
                "df2dx1", "df2dx2");
            res += "\n";

            double xk = (leftX + rightX) / 2;
            double yk = (leftY + rightY) / 2;
            double prevxk = xk, prevyk = yk;

            int iter = 0;
            while (iter <= iterations)
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

                res += PrintStringNewton(
                    iter.ToString(), Str(xk), Str(f1), Str(df1dx),
                    Str(df1dy), Str(detA1k), Str(detA2k), Str(detJk),
                    Str(yk), Str(f2), Str(df2dx), Str(df2dy));

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

            res += "\nAnswer:\n\n";

            res += "x = ";
            res += xk;
            res += "\ny = ";
            res += yk;
            return res;
        }

        public string Iterations()
        {
            string res = string.Empty;

            res += "Iterations Method:\n";
            double xk = (leftX + rightX) / 2;
            double yk = (leftY + rightY) / 2;
            double prevxk = xk, prevyk = yk;

            // Получение матрицы Якоби
            double f1 = solver.Solve(function1Tokens, xk, yk, a);
            double f2 = solver.Solve(function2Tokens, xk, yk, a);

            double f1rightX = solver.Solve(function1Tokens, xk + epsilon, yk, a);
            double df1dx = (f1rightX - f1) / epsilon;
            double f1rightY = solver.Solve(function1Tokens, xk, yk + epsilon, a);
            double df1dy = (f1rightY - f1) / epsilon;

            double f2rightX = solver.Solve(function2Tokens, xk + epsilon, yk, a);
            double df2dx = (f2rightX - f2) / epsilon;
            double f2rightY = solver.Solve(function2Tokens, xk, yk + epsilon, a);
            double df2dy = (f2rightY - f2) / epsilon;

            Matrix Jk = new Matrix(2);
            Jk[0, 0] = df1dx;
            Jk[0, 1] = df1dy;
            Jk[1, 0] = df2dx;
            Jk[1, 1] = df2dy;

            // Дихотомия: ищем координату x
            double lx = leftX, rx = rightX, ly = leftY, ry = rightY, step = 1.0 / 3;
            while (Math.Abs(lx - rx) > epsilon)
            {
                double lk = lx + step * (rx - lx);
                double rk = rx - step * (rx - lx);
                double f1Lk = solver.Solve(function1Tokens, lk, yk, a);
                double f2Lk = solver.Solve(function2Tokens, lk, yk, a);

                double f1rightXLk = solver.Solve(function1Tokens, lk + epsilon, yk, a);
                double df1dxLk = (f1rightXLk - f1Lk) / epsilon;
                double f1rightYLk = solver.Solve(function1Tokens, lk, yk + epsilon, a);
                double df1dyLk = (f1rightYLk - f1Lk) / epsilon;

                double f2rightXLk = solver.Solve(function2Tokens, lk + epsilon, yk, a);
                double df2dxLk = (f2rightXLk - f2Lk) / epsilon;
                double f2rightYLk = solver.Solve(function2Tokens, lk, yk + epsilon, a);
                double df2dyLk = (f2rightYLk - f2Lk) / epsilon;

                // Матрица Якоби для левой точки 
                Matrix JkLk = new Matrix(2);
                JkLk[0, 0] = df1dxLk;
                JkLk[0, 1] = df1dyLk;
                JkLk[1, 0] = df2dxLk;
                JkLk[1, 1] = df2dyLk;

                double f1Rk = solver.Solve(function1Tokens, rk, yk, a);
                double f2Rk = solver.Solve(function2Tokens, rk, yk, a);

                double f1rightXRk = solver.Solve(function1Tokens, rk + epsilon, yk, a);
                double df1dxRk = (f1rightXRk - f1Rk) / epsilon;
                double f1rightYRk = solver.Solve(function1Tokens, rk, yk + epsilon, a);
                double df1dyRk = (f1rightYRk - f1Rk) / epsilon;

                double f2rightXRk = solver.Solve(function2Tokens, rk + epsilon, yk, a);
                double df2dxRk = (f2rightXRk - f2Rk) / epsilon;
                double f2rightYRk = solver.Solve(function2Tokens, rk, yk + epsilon, a);
                double df2dyRk = (f2rightYRk - f2Rk) / epsilon;

                // Матрица Якоби для правой точки
                Matrix JkRk = new Matrix(2);
                JkRk[0, 0] = df1dxRk;
                JkRk[0, 1] = df1dyRk;
                JkRk[1, 0] = df2dxRk;
                JkRk[1, 1] = df2dyRk;

                if (JkLk.Norm() < JkRk.Norm())
                {
                    lx = lk;
                }
                else
                {
                    rx = rk;
                }
            }
            double maxXNormJkIdx = (lx + rx) / 2;

            // Дихотомия: ищем координату y
            while (Math.Abs(ly - ry) > epsilon)
            {
                double lk = ly + step * (ry - ly);
                double rk = ry - step * (ry - ly);

                double f1Lk = solver.Solve(function1Tokens, maxXNormJkIdx, lk, a);
                double f2Lk = solver.Solve(function2Tokens, maxXNormJkIdx, lk, a);

                double f1rightXLk = solver.Solve(function1Tokens, maxXNormJkIdx + epsilon, lk, a);
                double df1dxLk = (f1rightXLk - f1Lk) / epsilon;
                double f1rightYLk = solver.Solve(function1Tokens, maxXNormJkIdx, lk + epsilon, a);
                double df1dyLk = (f1rightYLk - f1Lk) / epsilon;

                double f2rightXLk = solver.Solve(function2Tokens, maxXNormJkIdx + epsilon, lk, a);
                double df2dxLk = (f2rightXLk - f2Lk) / epsilon;
                double f2rightYLk = solver.Solve(function2Tokens, maxXNormJkIdx, lk + epsilon, a);
                double df2dyLk = (f2rightYLk - f2Lk) / epsilon;

                Matrix JkLk = new Matrix(2);
                JkLk[0, 0] = df1dxLk;
                JkLk[0, 1] = df1dyLk;
                JkLk[1, 0] = df2dxLk;
                JkLk[1, 1] = df2dyLk;

                double f1Rk = solver.Solve(function1Tokens, maxXNormJkIdx, rk, a);
                double f2Rk = solver.Solve(function2Tokens, maxXNormJkIdx, rk, a);

                double f1rightXRk = solver.Solve(function1Tokens, maxXNormJkIdx + epsilon, rk, a);
                double df1dxRk = (f1rightXRk - f1Rk) / epsilon;
                double f1rightYRk = solver.Solve(function1Tokens, maxXNormJkIdx, rk + epsilon, a);
                double df1dyRk = (f1rightYRk - f1Rk) / epsilon;

                double f2rightXRk = solver.Solve(function2Tokens, maxXNormJkIdx + epsilon, rk, a);
                double df2dxRk = (f2rightXRk - f2Rk) / epsilon;
                double f2rightYRk = solver.Solve(function2Tokens, maxXNormJkIdx, rk + epsilon, a);
                double df2dyRk = (f2rightYRk - f2Rk) / epsilon;

                Matrix JkRk = new Matrix(2);
                JkRk[0, 0] = df1dxRk;
                JkRk[0, 1] = df1dyRk;
                JkRk[1, 0] = df2dxRk;
                JkRk[1, 1] = df2dyRk;

                if (JkLk.Norm() < JkRk.Norm())
                {
                    ly = lk;
                }
                else
                {
                    ry = rk;
                }
            }
            double maxYNormJkIdx = (ly + ry) / 2;
            
            res += $"{maxXNormJkIdx}    {maxYNormJkIdx}";

            f1 = solver.Solve(function1Tokens, maxXNormJkIdx, maxYNormJkIdx, a);
            f2 = solver.Solve(function2Tokens, maxXNormJkIdx, maxYNormJkIdx, a);

            f1rightX = solver.Solve(function1Tokens, maxXNormJkIdx + epsilon, maxYNormJkIdx, a);
            df1dx = (f1rightX - f1) / epsilon;
            f1rightY = solver.Solve(function1Tokens, maxXNormJkIdx, maxYNormJkIdx + epsilon, a);
            df1dy = (f1rightY - f1) / epsilon;

            f2rightX = solver.Solve(function2Tokens, maxXNormJkIdx + epsilon, maxYNormJkIdx, a);
            df2dx = (f2rightX - f2) / epsilon;
            f2rightY = solver.Solve(function2Tokens, maxXNormJkIdx, maxYNormJkIdx + epsilon, a);
            df2dy = (f2rightY - f2) / epsilon;

            Jk = new Matrix(2);
            Jk[0, 0] = df1dx;
            Jk[0, 1] = df1dy;
            Jk[1, 0] = df2dx;
            Jk[1, 1] = df2dy;

            double q = Jk.Norm();

            res += "q = ";
            res += q.ToString();
            res += "\n\n";

            res += PrintStringIterations("k", "x1(k)", "f1(x1, x2)", "x2(k)", "f2(x1, x2)");
            res += "\n";

            int iter = 0;
            while (iter <= iterations)
            {
                f1 = solver.Solve(function1Tokens, xk, yk, a);
                f2 = solver.Solve(function2Tokens, xk, yk, a);

                res += PrintStringIterations(
                    iter.ToString(), Str(xk), Str(f1), Str(yk), Str(f2));

                f1rightX = solver.Solve(function1Tokens, xk + epsilon, yk, a);
                df1dx = (f1rightX - f1) / epsilon;
                f1rightY = solver.Solve(function1Tokens, xk, yk + epsilon, a);
                df1dy = (f1rightY - f1) / epsilon;

                f2rightX = solver.Solve(function2Tokens, xk + epsilon, yk, a);
                df2dx = (f2rightX - f2) / epsilon;
                f2rightY = solver.Solve(function2Tokens, xk, yk + epsilon, a);
                df2dy = (f2rightY - f2) / epsilon;

                Jk = new Matrix(2);
                Jk[0, 0] = df1dx;
                Jk[0, 1] = df1dy;
                Jk[1, 0] = df2dx;
                Jk[1, 1] = df2dy;
                double detJk = Jk[0, 0] * Jk[1, 1] - Jk[0, 1] * Jk[1, 0];
                Matrix T = new Matrix(2);
                T[0, 0] = Jk[1, 1];
                T[0, 1] = -Jk[1, 0];
                T[1, 0] = -Jk[0, 1];
                T[1, 1] = Jk[0, 0];
                T *= (1 / detJk);

                xk = prevxk - (f1 * T[0, 0] + f2 * T[0, 1]);
                yk = prevyk - (f1 * T[1, 0] + f2 * T[1, 1]);

                if ((q / (1 - q)) * Math.Max(Math.Abs(xk - prevxk), Math.Abs(yk - prevyk)) >= epsilon) // искать q = max(||J||) на области
                {
                    res += PrintStringIterations(
                    "ok", Str(xk), Str(f1), Str(yk), Str(f2));
                    res += "\n";
                    break;
                }

                prevxk = xk;
                prevyk = yk;
                iter++;
            }

            res += "\nAnswer:\n\n";

            res += "x = ";
            res += xk;
            res += "\ny = ";
            res += yk;

            return res;
        }
    }
}
