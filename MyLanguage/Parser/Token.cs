namespace MyLanguage.Parser
{
    public class Token
    {

        private TokenType type;
        private string text;

        public Token()
        {
        }

        public Token(TokenType type, string text)
        {
            this.type = type;
            this.text = text;
        }

        public TokenType Type
        {
            get => type;
            set => type = value;
        }


        public string Text
        {
            get => text;
            set => text = value;
        }


        public override string ToString()
        {
            return type + " " + text;
        }
    }
}
