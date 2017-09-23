using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.IEnumerable
{
    public static class IEnumerable
    {
        public static void Print<T>(this IEnumerable<T> @this)
        {
            foreach (var item in @this)
            {
                Console.WriteLine(item);
            }
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> @this)
        {
            return @this == null || !@this.Any();
        }
    }
}
