using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WindowsFormsApp1.Equation.Token;

namespace WindowsFormsApp1.Equation
{
    internal class Solver
    {
        public Solver() { }

        public double Solve(List<Token> f, double x1, double x2, double x3)
        {
            Stack<double> stack = new Stack<double>();
            for (int i = 0; i < f.Count; i++)
            {
                if (f[i].Type == Token.TokenType.Number)
                {
                    stack.Push(f[i].ValueAsDouble);
                }
                else if (f[i].Type == Token.TokenType.Variable)
                {
                    if (f[i].Value == "x" || f[i].Value == "x1")
                    {
                        stack.Push(x1);
                    }
                    else if (f[i].Value == "y" || f[i].Value == "x2")
                    {
                        stack.Push(x2);
                    }
                    else if (f[i].Value == "y'" || f[i].Value == "z")
                    {
                        stack.Push(x3);
                    }
                }
                else if (f[i].Type == Token.TokenType.Function)
                {
                    double funcRes = 0;
                    double tmp = stack.Pop();
                    if (f[i].Value == "sqrt")
                    {
                        if (tmp < 0)
                        {
                            return 0;
                        }
                        funcRes = Math.Sqrt(tmp);
                    }
                    else if (f[i].Value == "ln")
                    {
                        if (tmp <= 0)
                        {
                            return 0;
                        }
                        funcRes = Math.Log(tmp);
                    }
                    else if (f[i].Value == "lg")
                    {
                        if (tmp <= 0)
                        {
                            return 0;
                        }

                        funcRes = Math.Log10(tmp);
                    }
                    else if (f[i].Value == "cos")
                    {
                        funcRes = Math.Cos(tmp);
                    }
                    else if (f[i].Value == "sin")
                    {
                        funcRes = Math.Sin(tmp);
                    }
                    else if (f[i].Value == "arccos")
                    {
                        funcRes = Math.Acos(tmp);
                    }
                    else if (f[i].Value == "arcsin")
                    {
                        funcRes = Math.Asin(tmp);
                    }
                    else if (f[i].Value == "tg")
                    {
                        if (tmp == Math.PI / 2)
                        {
                            return 0;
                        }
                        funcRes = Math.Tan(tmp);
                    }
                    else if (f[i].Value == "exp")
                    {
                        funcRes = Math.Exp(tmp);
                    }
                    stack.Push(funcRes);
                }
                else if (f[i].Type == Token.TokenType.Operator)
                {
                    var tmp2 = stack.Pop();
                    var tmp1 = stack.Pop();
                    if (f[i].Value == "+")
                    {
                        stack.Push(tmp1 + tmp2);
                    }
                    else if (f[i].Value == "-")
                    {
                        stack.Push(tmp1 - tmp2);
                    }
                    else if (f[i].Value == "*")
                    {
                        stack.Push(tmp1 * tmp2);
                    }
                    else if (f[i].Value == "/")
                    {
                        if (tmp1 == 0)
                        {
                            return 0;
                        }
                        stack.Push(tmp1 / tmp2);
                    }
                    else if (f[i].Value == "^")
                    {
                        stack.Push(Math.Pow(tmp1, tmp2));
                    }
                }
                else if (f[i].Type == Token.TokenType.UnaryOperator)
                {
                    var tmp = stack.Pop();
                    if (f[i].Value == "-")
                    {
                        tmp *= (-1);
                    }
                    stack.Push(tmp);
                }
            }
            return stack.Peek();
        }

        public List<double> GetConstraints(List<Token> tokens)
        {
            List<double> constraints = new List<double>(new double[3]);
            Stack<Token> stack = new Stack<Token>();
            foreach (var token in tokens)
            {
                if (token.Type == TokenType.Variable)
                {
                    stack.Push(token);
                }
                else if (token.Type == TokenType.Number)
                {
                    stack.Push(token);
                }
                else if (token.Type == TokenType.Operator)
                {
                    if (token.Value == "=")
                    {
                        double c = stack.Pop().ValueAsDouble;
                        constraints[2] = c;
                        if (stack.Count != 0)
                        {
                            Token rank = stack.Pop();
                            if (rank.Value == "y")
                            {
                                constraints[0] = 1;
                            }
                            else
                            {
                                constraints[1] = 1;
                            }
                        }
                    }
                    else if (token.Value == "*")
                    {
                        stack.Pop();
                        Token rank = stack.Pop();
                        double constr = stack.Pop().ValueAsDouble;
                        if (rank.Value == "y")
                        {
                            constraints[0] = constr;
                        }
                        else
                        {
                            constraints[1] = constr;
                        }
                        stack.Push(rank);
                    }
                    else if (token.Value == "-" || token.Value == "+")
                    {
                        Token rank = stack.Pop();
                        stack.Pop();
                        if (rank.Type == TokenType.Variable)
                        {
                            if (token.Value == "-")
                            {
                                if (rank.Value == "y")
                                {
                                    constraints[0] *= (-1);
                                    if (stack.Count != 0)
                                    {
                                        constraints[1] = 1;
                                    }
                                }
                                else
                                {
                                    constraints[1] *= (-1);
                                    if (stack.Count != 0)
                                    {
                                        constraints[0] = 1;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (token.Type == TokenType.UnaryOperator)
                {
                    var tmp = stack.Pop();
                    if (token.Value == "-")
                    {
                        tmp.Value = token.Value + tmp.Value;
                        tmp.ValueAsDouble *= (-1);
                    }
                    stack.Push(tmp);
                }
            }
            return constraints;
        }
    }
}
