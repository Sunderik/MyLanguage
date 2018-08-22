namespace MyLanguage.Parser.AST
{
    public sealed class BinaryExpression : IExpression
    {
        private readonly IExpression expr1, expr2;
        private readonly char operation;
        public BinaryExpression(char operation, IExpression expr1, IExpression expr2)
        {
            this.operation = operation;
            this.expr1 = expr1;
            this.expr2 = expr2;
        }
        public int Eval()
        {
            int result;
            switch (operation)
            {
                case '-':
                    result= expr1.Eval() - expr2.Eval();break;
                case '+':
                    result= expr1.Eval() + expr2.Eval(); break;
                case '/':
                    result= expr1.Eval() / expr2.Eval(); break;
                case '*':
                    result= expr1.Eval() * expr2.Eval(); break;
                case '%':
                    result= expr1.Eval() % expr2.Eval(); break;
                default: result= -999; break;
            }
            return result;
        }

        public override string ToString()
        {
            return string.Format("({0} {1} {2})", expr1, operation, expr2);
        }
    }
}
