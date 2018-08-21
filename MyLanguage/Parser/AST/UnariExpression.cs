namespace MyLanguage.Parser.AST
{
    public sealed class UnaryExpression : IExpression
    {
        private readonly IExpression expr1;
        private readonly char operation;

        public UnaryExpression(char operation, IExpression expr1)
        {
            this.operation = operation;
            this.expr1 = expr1;
        }

        public int Eval()
        {
            switch (operation)
            {
                case '-':
                    return -expr1.Eval();
                case '+':
                default:
                    return expr1.Eval();
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", operation, expr1);
        }
    }
}
