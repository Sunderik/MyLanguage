﻿using System;
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

        public IList<IExpression> Parse()
        {
            IList<IExpression> result = new List<IExpression>();
            if (tokens[0].Type == TokenType.DO)
            {
                while (!Match(TokenType.EOF))
                {
                    result.Add(Expression());
                }
                return result;
            }
            else throw new Exception("No executed command");
        }

        //private IExpression Function()
        //{
        //    string name = consume(TokenType.WORD).Text;
        //    List<string> argNames = new List<string>();
        //    while (!Match(TokenType.EQ))
        //    {
        //        argNames.Add(consume(TokenType.WORD).Text);
        //        Match(TokenType.COMMA);
        //    }
        //}

        private IExpression Expression()
        {
            return Conditional();
        }

        private IExpression Conditional()
        {
            IExpression result = Additive();

            while (true)
            {
                if (Match(TokenType.EQEQ))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operators.EQEQ, result, Additive());
                    continue;
                }
                if (Match(TokenType.EXCLEQ))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operators.EXCLEQ, result, Additive());
                    continue;
                }
                if (Match(TokenType.LT))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operators.LT, result, Additive());
                    continue;
                }
                if (Match(TokenType.LTEQ))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operators.LTEQ, result, Additive());
                    continue;
                }
                if (Match(TokenType.GT))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operators.GT, result, Additive());
                    continue;
                }
                if (Match(TokenType.GTEQ))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operators.GTEQ, result, Additive());
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
            if (Match(TokenType.IF))
            {
                IExpression cond = Expression();

                IfExpression ret = new IfExpression(cond,Get(0),Get(1));
                pos++;pos++;
                return ret;
            }
            //if (Match(TokenType.LET))
            //{
            //    return Function();
            //}
            if (Match(TokenType.LBRACKET))
            {
                IExpression result = Expression();
                Match(TokenType.RBRACKET);
                return result;
            }
            throw new Exception("Unknown expression");
        }

        private Token consume(TokenType type)
        {
            Token current = Get(0);
            if (type != current.Type) throw new Exception("Token " + current + " doesn't match " + type);
            pos++;
            return current;
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
