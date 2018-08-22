namespace MyLanguage.Parser.AST
{
    public sealed class ConditionalExpression : IExpression
    {
        public enum Operators
        {
            EQEQ,
            EXCLEQ,
            LT,
            LTEQ,
            GT,
            GTEQ
        }

        private readonly IExpression expr1, expr2;
        private readonly Operators operation;

        public ConditionalExpression(Operators operation, IExpression expr1, IExpression expr2)
        {
            this.operation = operation;
            this.expr1 = expr1;
            this.expr2 = expr2;
        }
        public int Eval()
        {
            switch (operation)
            {
                case Operators.LT: return expr1.Eval() < expr2.Eval() ? 1 : 0;
                case Operators.LTEQ: return expr1.Eval() <= expr2.Eval() ? 1 : 0;
                case Operators.GT: return expr1.Eval() > expr2.Eval() ? 1 : 0;
                case Operators.GTEQ: return expr1.Eval() >= expr2.Eval() ? 1 : 0;
                case Operators.EXCLEQ: return expr1.Eval() != expr2.Eval() ? 1 : 0;
                case Operators.EQEQ:
                default: return expr1.Eval() == expr2.Eval() ? 1 : 0;
            }
        }

        public override string ToString()
        {
            return string.Format("({0} {1} {2})", expr1, operation, expr2);
        }
    }
}
