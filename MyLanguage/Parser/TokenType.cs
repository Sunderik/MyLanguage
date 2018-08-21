
namespace MyLanguage.Parser
{
    public enum TokenType
    {

        NUMBER,
        WORD,

        //keyword
        DO,
        LET,
        IF,


        PLUS,
        MINUS,
        MULTIPLY,
        DEVIDE,
        PERCENT,


        LBRACKET, // (
        RBRACKET, // )
        COMENT, //;
        EQ, //=
        LT, //<
        GT, //>
        EOF

    }
}
