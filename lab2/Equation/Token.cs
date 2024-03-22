using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Equation
{
    internal class Token
    {
        public enum TokenType
        {
            Number,
            Variable,
            Operator,
            UnaryOperator,
            Function,
            Parameter,
            OpenParenthesis,
            CloseParenthesis 
        }

        public TokenType Type { get; private set; }
        
        public string Value { get; private set; }
        public double ValueAsDouble { get; private set; }

        public int Priority { get; private set; }
        
        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
            if (Type == TokenType.Number)
            {
                ValueAsDouble = Double.Parse(value);
            }
            if (Type == TokenType.Function || Type == TokenType.UnaryOperator || (Type == TokenType.Operator && Value == "^"))
            {
                Priority = 3;
            }
            else if (Type == TokenType.Operator && (Value == "*" || Value == "/"))
            {
                Priority = 2;
            }
            else if (Type == TokenType.Operator && (Value == "+" || Value == "-"))
            {
                Priority = 1;
            }
            else
            {
                Priority = 0;
            }
        }

        public Token(double value)
        {
            Type = TokenType.Number;
            ValueAsDouble = value;
            Value = Math.Round(value, 4).ToString();
            Priority = 0;
        }
        
        public override string ToString()
        {
            return $"{Type}: {Value}\n";
        }
    }
}
