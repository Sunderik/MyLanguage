using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLanguage.Parser.AST
{
    public sealed class WordExpression : IExpression
    {
        private readonly string value;
        public WordExpression(string value)
        {
            this.value = value;
        }
        public int Eval()
        {
            return 0;
        }
        public override string ToString()
        {
            return value;
        }
    }
}
