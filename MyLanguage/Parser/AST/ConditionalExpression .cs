namespace MyLanguage.Parser.AST
{
    public sealed class ConditionalExpression : IExpression
    {
        private readonly IExpression expr1, expr2;
        private readonly char operation;

        public ConditionalExpression(char operation, IExpression expr1, IExpression expr2)
        {
            this.operation = operation;
            this.expr1 = expr1;
            this.expr2 = expr2;
        }
        public int Eval()
        {
            switch (operation)
            {
                case '>':
                    return expr1.Eval() > expr2.Eval() ? 1 : 0;
                case '<':
                    return expr1.Eval() < expr2.Eval() ? 1 : 0;
                case '=':
                default: return expr1.Eval() == expr2.Eval() ? 1 : 0;
            }
        }

        public override string ToString()
        {
            return string.Format("({0} {1} {2})", expr1, operation, expr2);
        }
    }
}
