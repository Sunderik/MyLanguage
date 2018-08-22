using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLanguage.Lib
{
   public interface IFunction
    {
        int Execute(List<int> args);
    }
}
