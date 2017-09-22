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
            int integer = 0;
            string text = "some text";
            char c = 'a';
            double d = 1.1;

            if (integer > 0)
            {
                Console.WriteLine(integer);
            } else if (text.Length > 0)
            {
                Console.WriteLine(text);
            } else
            {
                Console.WriteLine(d);
            }

            Console.WriteLine("This is it");
        }
    }
}
