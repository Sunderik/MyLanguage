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
                Console.Write("Enter a way to the file with the program: ");
                string path = Console.ReadLine();
                try
                {
                    string[] input = File.ReadAllLines(path);


                    foreach (string str in input)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            IList<Pars.Token> tokens = (new Pars.Lexer(str)).Tokenize();
                            //foreach (Pars.Token token in tokens)
                            //{
                            //    Console.WriteLine(token);
                            //}
                            if (tokens.Count > 0)
                            {
                                IList<IExpression> expressions = (new Pars.Parser(tokens)).Parse();
                                if (expressions[0].ToString()=="") expressions.RemoveAt(0);
                                if(expressions.Count>1)
                                {
                                        Console.WriteLine("Result: {0}", expressions[expressions.Count-1].Eval());
                                }
                                else Console.WriteLine("Result: {0}", expressions[0].Eval());

                            }
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
