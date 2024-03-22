using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static app.Equation.Token;

namespace app.Equation
{
    internal class Parser
    {
        public Parser() { }

        public List<Token> ToPostfix(List<Token> infix)
        {
            var outputQueue = new Queue<Token>();
            var operatorStack = new Stack<Token>();

            foreach (var token in infix)
            {
                switch (token.Type)
                {
                    case TokenType.Number:
                        outputQueue.Enqueue(token);
                        break;

                    case TokenType.Parameter:
                        outputQueue.Enqueue(token);
                        break;

                    case TokenType.Variable:
                        outputQueue.Enqueue(token);
                        break;

                    case TokenType.Function:
                        operatorStack.Push(token);
                        break;

                    case TokenType.UnaryOperator:
                        operatorStack.Push(token);
                        break;

                    case TokenType.Operator:
                        while (operatorStack.Any() &&
                               operatorStack.Peek().Type != TokenType.OpenParenthesis &&
                               operatorStack.Peek().Priority > token.Priority)
                        {
                            outputQueue.Enqueue(operatorStack.Pop());
                        }
                        operatorStack.Push(token);
                        break;

                    case TokenType.OpenParenthesis:
                        operatorStack.Push(token);
                        break;

                    case TokenType.CloseParenthesis:
                        while (operatorStack.Peek().Type != TokenType.OpenParenthesis)
                        {
                            outputQueue.Enqueue(operatorStack.Pop());
                        }
                        operatorStack.Pop();
                        if (operatorStack.Any() && operatorStack.Peek().Type == TokenType.Function)
                        {
                            outputQueue.Enqueue(operatorStack.Pop());
                        }
                        break;
                }
            }

            while (operatorStack.Any())
            {
                outputQueue.Enqueue(operatorStack.Pop());
            }

            return outputQueue.ToList();
        }

        public string ToInfix(List<Token> postfix)
        {
            string res = string.Empty;
            Stack<List<Token>> stack = new Stack<List<Token>>();
            for (int i = 0; i < postfix.Count; i++)
            {
                if (postfix[i].Type == TokenType.Number || 
                    postfix[i].Type == TokenType.Variable || 
                    postfix[i].Type == TokenType.Parameter)
                {
                    stack.Push(new List<Token>() { postfix[i] });
                }
                else if (postfix[i].Type == TokenType.Function || postfix[i].Type == TokenType.UnaryOperator)
                {
                    var tmp = stack.Pop();
                    var tmp2 = new List<Token>
                    {
                        postfix[i],
                        new Token(TokenType.OpenParenthesis, "(")
                    };
                    foreach (var tmpToken in tmp)
                    {
                        tmp2.Add(tmpToken);
                    }
                    tmp2.Add(new Token(TokenType.CloseParenthesis, ")"));
                    stack.Push(tmp2);
                }
                else if (postfix[i].Type == TokenType.Operator)
                {
                    var tmp = stack.Pop();
                    var tmp2 = stack.Pop();
                    var tmp3 = new List<Token>
                    {
                        new Token(TokenType.OpenParenthesis, "(")
                    };
                    foreach (var tmpToken in tmp2)
                    {
                        tmp3.Add(tmpToken);
                    }
                    tmp3.Add(postfix[i]);
                    foreach (var tmpToken in tmp)
                    {
                        tmp3.Add(tmpToken);
                    }
                    tmp3.Add(new Token(TokenType.CloseParenthesis, ")"));
                    stack.Push(tmp3);
                }
            }
            for (int i = 0; i < stack.Peek().Count; i++)
            {
                res += stack.Peek()[i].Value;
            }
            return res;
        }

        public (List<Token>, List<Token>) Split(List<Token> postfix)
        {
            var lastOp = postfix.Count - 3;
            Stack<List<Token>> stack = new Stack<List<Token>>();
            
            for (int i = 0; i < lastOp; i++)
            {
                if (postfix[i].Type == TokenType.Number || 
                    postfix[i].Type == TokenType.Variable || 
                    postfix[i].Type == TokenType.Parameter)
                {
                    stack.Push(new List<Token>() { postfix[i] });
                }
                else if (postfix[i].Type == TokenType.Function || postfix[i].Type == TokenType.UnaryOperator)
                {
                    stack.Peek().Add(postfix[i]);
                }
                else if (postfix[i].Type == TokenType.Operator)
                {
                    var tmp = stack.Pop();
                    foreach (var t in tmp)
                    {
                        stack.Peek().Add(t);
                    }
                    stack.Peek().Add(postfix[i]);
                }
            }
            var f1 = stack.Pop();
            var f2 = stack.Pop();

            f2.Add(new Token(TokenType.UnaryOperator, "-"));

            return (f1, f2);
        }
    }
}
