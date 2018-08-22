using System;
using System.Collections.Generic;
using MyLanguage.Library;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLanguage.Parser.AST
{
    public sealed class FunctionExpression : IExpression
    {
        private string name;
        private List<Token> arguments;
        private List<Token> expressionTokens;
        private IExpression expression;

        public FunctionExpression(string name, List<Token> arguments,   List<Token> expression)
        {
            this.name = name;
            this.arguments = arguments;
            this.expressionTokens = expression;
            Functions.Set(new Function(name, arguments, expression));
        }

        public int Eval()
        {

            return 101;
        }
    }
}
