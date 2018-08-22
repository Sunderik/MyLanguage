using System.Collections.Generic;
using System.Text;
using System;

namespace MyLanguage.Parser
{
    class Lexer
    {
        private const string operator_chars = ";+-*/%()=<>!";
        private static readonly Dictionary<string, TokenType> Map = new Dictionary<string, TokenType>()
        {
           {";",TokenType.COMENT },
           {"+",TokenType.PLUS },
           {"-",TokenType.MINUS },
           {"*",TokenType.MULTIPLY },
           {"/",TokenType.DEVIDE },
           {"%",TokenType.PERCENT },
           {"(", TokenType.LBRACKET },
           {")", TokenType.RBRACKET },
           {"==",TokenType.EQEQ },
           {"!=",TokenType.EXCLEQ },
           {"<", TokenType.LT },
           {"<=",TokenType.LTEQ },
           {">", TokenType.GT },
           {">=",TokenType.GTEQ }
        };
        private bool nocomment = false;
        private readonly string input;
        private readonly int length;
        private readonly IList<Token> tokens;

        private int pos;

        public Lexer(string input)
        {
            this.input = input;
            length = input.Length;

            tokens = new List<Token>();
        }

        public IList<Token> Tokenize()
        {
            while (pos < length && nocomment == false)
            {
                char current = Peek(0);
                if (char.IsDigit(current))
                {
                    TokenizeNumber();
                }
                else if (char.IsLetter(current))
                {
                    TokenizeWord();
                }
                else if (operator_chars.IndexOf(current) != -1)
                {
                    TokenizeOperator();
                }
                else
                {
                    // whitespaces
                    Next();
                }
            }
            return tokens;
        }

        private void TokenizeNumber()
        {
            StringBuilder buffer = new StringBuilder();
            char current = Peek(0);
            while (char.IsDigit(current))
            {
                buffer.Append(current);
                current = Next();
            }
            AddToken(TokenType.NUMBER, buffer.ToString());
        }
        private void TokenizeWord()
        {
            StringBuilder buffer = new StringBuilder();
            char current = Peek(0);
            while (char.IsLetterOrDigit(current))
            {
                buffer.Append(current);
                current = Next();
            }
            string word = buffer.ToString().ToLower();
            switch (word)
            {
                case "do":
                    AddToken(TokenType.DO); break;
                case "if":
                    AddToken(TokenType.IF); break;
                case "let":
                    AddToken(TokenType.LET); break;
                default:
                    AddToken(TokenType.WORD, word);
                    break;
            }
        }
        private void TokenizeOperator()
        {
            char current = Peek(0);
            if (current == ';')
            {
                Next();
                TokenizeComment();
                return;
            }
                StringBuilder buffer = new StringBuilder();
            while (true)
            {
                string text = buffer.ToString();
                bool flag = Map.ContainsKey(text + current);
                if (!Map.ContainsKey(text + current) && !String.IsNullOrEmpty(text))
                {
                    AddToken(Map[text]);
                    return;
                }
                buffer.Append(current);
                current = Next();
            }
        }

        private void TokenizeComment()
        {
            char current = Peek(0);
            while ("\r\n\0".IndexOf(current) == -1)
            {
                current = Next();
            }
        }

        private char Next()
        {
            pos++;
            return Peek(0);
        }

        private char Peek(int relativePosition)
        {
            int position = pos + relativePosition;
            return (position >= length) ? '\0' : input[position];
        }

        private void AddToken(TokenType type)
        {
            if (type == TokenType.COMENT)
            {
                AddToken(type, input.Substring(pos));
                nocomment = true;
            }
            else
            {
                AddToken(type, "");
            }
        }

        private void AddToken(TokenType type, string text)
        {
            tokens.Add(new Token(type, text));
        }
    }
}
