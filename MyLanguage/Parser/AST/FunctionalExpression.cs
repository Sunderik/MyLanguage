using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLanguage.Parser.AST
{
   public sealed class FunctionalExpression : IExpression
    {
        private string name;
        private List<IExpression> arguments;

        public FunctionalExpression(string name) {
            this.name = name;
            this.arguments = new List<IExpression>();
        };
        public FunctionalExpression(string name, List<IExpression> arguments)
        {
            this.name = name;
            this.arguments = arguments;
        }

        public int Eval()
        {
            List<int> values = new List<int>(arguments.Count);
        }
    }
}
