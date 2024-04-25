﻿using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using app.Equation;
using static app.Equation.Token;

namespace app.Equation
{
    internal class Lexer
    {
        public Lexer() { }

        public List<Token> Run(string input)
        {
            List<Token> tokens = new List<Token>();
            int position = 0;
            bool expectUnary = true;

            while (position < input.Length)
            {
                char current = input[position];

                if (char.IsDigit(current) || current == '.')
                {
                    string number = ParseNumber(input, ref position);
                    tokens.Add(new Token(Token.TokenType.Number, number));
                    expectUnary = false;
                }
                else if ("+-*/=^".IndexOf(current) != -1)
                {
                    if (expectUnary && (current == '+' || current == '-'))
                    {
                        tokens.Add(new Token(TokenType.UnaryOperator, current.ToString()));
                    }
                    else
                    {
                        tokens.Add(new Token(TokenType.Operator, current.ToString()));
                    }
                    position++;
                    expectUnary = true;
                }
                else if (char.IsLetter(current))
                {
                    string word = ParseWord(input, ref position);
                    Token.TokenType type = IsFunction(word) ? Token.TokenType.Function : 
                        IsParameter(word) ? Token.TokenType.Parameter : 
                        Token.TokenType.Variable;
                    tokens.Add(new Token(type, word));
                    expectUnary = false;
                }
                else if (current == '(')
                {
                    tokens.Add(new Token(TokenType.OpenParenthesis, current.ToString()));
                    position++;
                    expectUnary = true;
                }
                else if (current == ')')
                {
                    tokens.Add(new Token(TokenType.CloseParenthesis, current.ToString()));
                    position++;
                    expectUnary = false;
                }
                else if (char.IsWhiteSpace(current))
                {
                    position++;
                }
                else
                {
                    throw new InvalidOperationException($"Unexpected character: {current}");
                }
            }

            return tokens;
        }

        private string ParseNumber(string input, ref int position)
        {
            int start = position;
            while (position < input.Length && (char.IsDigit(input[position]) || input[position] == ','))
            {
                position++;
            }
            return input.Substring(start, position - start);
        }

        private string ParseWord(string input, ref int position)
        {
            int start = position;
            while (position < input.Length && (char.IsLetter(input[position]) || char.IsDigit(input[position])))
            {
                position++;
            }
            return input.Substring(start, position - start);
        }

        private bool IsFunction(string word)
        {
            string[] functions = { "sqrt", "ln", "lg", "cos", "sin", "tg", "exp", "arcsin", "arccos" };
            return Array.IndexOf(functions, word) != -1;
        }

        private bool IsParameter(string word)
        {
            string[] functions = { "a" };
            return Array.IndexOf(functions, word) != -1;
        }
    }
}