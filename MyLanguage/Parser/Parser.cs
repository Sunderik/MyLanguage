using System;
using System.Collections.Generic;
using MyLanguage.Parser.AST;


namespace MyLanguage.Parser
{
    class Parser
    {
        private static readonly Token EOF = new Token(TokenType.EOF, "");

        private readonly IList<Token> tokens;
        private readonly int size;

        private int pos;

        public Parser(IList<Token> tokens)
        {
            this.tokens = tokens;
            size = tokens.Count;
        }

        public IList<IExpression> parse()
        {
            IList<IExpression> result = new List<IExpression>();
            if (tokens[0].Type == TokenType.DO || tokens[0].Type == TokenType.COMENT)
            {
                while (!Match(TokenType.EOF))
                {
                    result.Add(Expression());
                }
                return result;
            }
            else throw new Exception("No executed command");
        }

        private IExpression Expression()
        {
            return Conditional();
        }

        private IExpression Conditional()
        {
            IExpression result = Additive();

            while (true)
            {
                if (Match(TokenType.EQ))
                {
                    result = new ConditionalExpression('=', result, Multiplicative());
                    continue;
                }
                if (Match(TokenType.LT))
                {
                    result = new ConditionalExpression('<', result, Multiplicative());
                    continue;
                }
                if (Match(TokenType.GT))
                {
                    result = new ConditionalExpression('>', result, Multiplicative());
                    continue;
                }
                break;
            }
            return result;
        }
        
        private IExpression Additive()
        {
            IExpression result = Multiplicative();

            while (true)
            {
                if (Match(TokenType.PLUS))
                {
                    result = new BinaryExpression('+', result, Multiplicative());
                    continue;
                }
                if (Match(TokenType.MINUS))
                {
                    result = new BinaryExpression('-', result, Multiplicative());
                    continue;
                }
                break;
            }
            return result;
        }

        private IExpression Multiplicative()
        {
            IExpression result = Unary();

            while (true)
            {
                if (Match(TokenType.MULTIPLY))
                {
                    result = new BinaryExpression('*', result, Unary());
                    continue;
                }
                if (Match(TokenType.DEVIDE))
                {
                    result = new BinaryExpression('/', result, Unary());
                    continue;
                }
                if (Match(TokenType.PERCENT))
                {
                    result = new BinaryExpression('%', result, Unary());
                    continue;
                }
                break;
            }

            return result;
        }

        private IExpression Unary()
        {
            if (Match(TokenType.MINUS))
            {
                return new UnaryExpression('-', Primary());
            }
            if (Match(TokenType.PLUS))
            {
                return Primary();
            }
            return Primary();
        }

        private IExpression Primary()
        {
            Token current = Get(0);
            if (Match(TokenType.NUMBER))
            {
                return new NumberExpression(int.Parse(current.Text));
            }
            if (Match(TokenType.DO))
            {
                return new WordExpression(current.Text);
            }
            if (Match(TokenType.WORD))
            {
                return new WordExpression(current.Text);
            }
            if (Match(TokenType.LBRACKET))
            {
                IExpression result = Expression();
                Match(TokenType.RBRACKET);
                return result;
            }
            if (Match(TokenType.COMENT))
            {
                return new WordExpression(current.Text);
            }
            throw new Exception("Unknown expression");
        }

        private bool Match(TokenType type)
        {
            Token current = Get(0);
            if (type != current.Type)
            {
                return false;
            }
            pos++;
            return true;
        }

        private Token Get(int relativePosition)
        {
            int position = pos + relativePosition;
            return (position >= size) ? EOF : tokens[position];
        }
    }
}
