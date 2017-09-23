using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS2
{
    class Program
    {
        static void Main(string[] args)
        {

            // Built in types
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/built-in-types-table

            int integer = 0;
            string text = "some text";
            char c = 'a';
            double d = 1.1;
            bool boolean = true;

            Console.WriteLine(c.GetType());
            Console.WriteLine(integer);
            Console.WriteLine(text);
            Console.WriteLine(c);
            Console.WriteLine(boolean);
            Console.WriteLine(d);


            Language.PrintExample();
        }  
    }
}
