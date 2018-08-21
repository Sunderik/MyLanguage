using System;

namespace MyLanguage.Parser.AST
{
    public sealed class NumberExpression : IExpression
    {
        private readonly int value;
        public NumberExpression(int value)
        {
            this.value = value;
        }
        public int Eval()
        {
            return value;
        }
        public override string ToString()
        {
            return Convert.ToString(value);
        }
    }
}
