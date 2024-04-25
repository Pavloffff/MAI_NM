﻿using app.Equation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static app.Equation.Token;

namespace app.Equation
{
    internal class Solver
    {
        public Solver() { }

        public double Solve(List<Token> f, double x1, double x2, double a)
        {
            Stack<double> stack = new Stack<double>();
            for (int i = 0; i < f.Count; i++)
            {
                if (f[i].Type == Token.TokenType.Number )
                {
                    stack.Push(f[i].ValueAsDouble);
                }
                else if (f[i].Type == Token.TokenType.Parameter)
                {
                    stack.Push(a);
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

        public Token d0(Token x)
        {
            if (x.Type == TokenType.Number || x.Type == TokenType.Parameter)
            {
                return new Token(TokenType.Number, 0.0.ToString());
            }
            else if (x.Type == TokenType.Variable)
            {
                return new Token(TokenType.Number, 1.0.ToString());
            }
            return x;
        }
    }
}