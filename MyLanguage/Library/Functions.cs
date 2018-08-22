using System.Collections.Generic;

namespace MyLanguage.Library
{
    public static class Functions
    {
        private static Dictionary<string, Function> functions = new Dictionary<string, Function>();

        public static void Set(Function func)
        {
            functions.Add(func.name, func);
        }
        public static Function Get(string name)
        {
            return functions[name];
        }
        public static bool Contains(string name)
        {
            return functions.ContainsKey(name);
        }
    }
}