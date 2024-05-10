using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Equation;

namespace WindowsFormsApp1.L4
{
    internal class Task2
    {
        private readonly double x0;
        private readonly double x1;
        private readonly double h;
        private List<double> c0;
        private List<double> c1;
        private List<Token> functionTokens;
        private List<Token> exactTokens;
        private Solver solver;
        
        public Task2(string f, double x0, double x1, string exact, string constr0, string constr1, double h)
        {
            var lexer = new Lexer();
            var parser = new Parser();
            solver = new Solver();
            functionTokens = lexer.Run(f);
            functionTokens = parser.ToPostfix(functionTokens);
            exactTokens = lexer.Run(exact);
            exactTokens = parser.ToPostfix(exactTokens);
            List<Token> constr0Tokens = lexer.Run(constr0);
            constr0Tokens = parser.ToPostfix(constr0Tokens);
            c0 = solver.GetConstraints(constr0Tokens);
            List<Token> constr1Tokens = lexer.Run(constr1);
            constr1Tokens = parser.ToPostfix(constr1Tokens);
            c1 = solver.GetConstraints(constr1Tokens);
            this.x0 = x0;
            this.x1 = x1;
            this.h = h;
        }

        public string Run()
        {
            string res = string.Empty;

            foreach (var token in c0)
            {
                res += token.ToString();
                res += " ";
            }

            res += "\n";

            foreach (var token in c1)
            {
                res += token.ToString();
                res += " ";
            }
            res += "\n";

            return res;
        }
    }
}
