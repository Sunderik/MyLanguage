using System;
using System.Collections.Generic;
using MyLanguage.Parser.AST;
using MyLanguage.Parser;
using System.Text.RegularExpressions;

namespace MyLanguage.Library
{
    public class Function
    {
        public string name;
        private List<Token> argumentsName;
        private List<Token> expressionTokens;
        private IExpression expression;

        public Function(string name, List<Token> argumentsName, List<Token> expression)
        {

            this.name = name;
            this.argumentsName = argumentsName;
            this.expressionTokens = expression;
        }

       public int Сalculate(List<Token> argeumnets)
        {
            return -404;
        }
    }
}
