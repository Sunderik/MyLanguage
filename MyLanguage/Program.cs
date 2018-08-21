using System;
using System.Collections.Generic;
using System.IO;
using Pars = MyLanguage.Parser;
using MyLanguage.Parser.AST;

namespace MyLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path = Console.ReadLine();
                try
                {
                    string[] input = File.ReadAllLines(path);

                    foreach (string str in input)
                    {
                        IList<Pars.Token> tokens = (new Pars.Lexer(str)).Tokenize();
                        //foreach (Pars.Token token in tokens)
                        //{
                        //    Console.WriteLine(token);
                        //}

                        IList<IExpression> expressions = (new Pars.Parser(tokens)).parse();
                        if (expressions.Count == 1)
                        {
                            if (!expressions[0].ToString().Contains(";"))
                                foreach (IExpression expr in expressions)
                                {
                                    Console.WriteLine("Result: {0}", expr.Eval());
                                }
                        }
                        else
                        {
                            IExpression expr = expressions[expressions.Count - 1].ToString().Contains(";") ? expressions[expressions.Count - 2] : expressions[expressions.Count - 1];
                            Console.WriteLine("Result: {0}", expr.Eval());
                        }
                    }
                }
                catch (Exception e) { Console.WriteLine("Exception: {0}", e.Message); }
                Console.ReadKey();
            }
            catch (Exception e) { Console.WriteLine(e.Message); };
        }
    }
}
