using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLanguage.Parser.AST
{
    class IfExpression:IExpression
    {
        IExpression cond;
        Token a, b;
        public IfExpression(IExpression cond,Token a, Token b)
        {
            this.cond = cond;
            this.a = a;
            this.b = b;
        }
        public int Eval()
        {
            return (cond.Eval()==1)? Convert.ToInt32(a.Text): Convert.ToInt32(b.Text);
        }
    }
}
