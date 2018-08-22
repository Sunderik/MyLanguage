using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLanguage.Lib
{
    public sealed class Functions 
    {
        private static  Dictionary<String, IFunction> functions;
        static Functions()
        {
            functions = new Dictionary<String, IFunction>();
        }

        public static bool IsExists(string key)
        {
            return functions.ContainsKey(key);
        }

        public static IFunction Get(string key)
        {
            if (!IsExists(key))
            {
                throw new Exception("Unknown Function " + key);
            }
            return functions[key];
        }

        public static void Set(string key, IFunction value)
        {
            functions.Add(key, value);
        }

    }
