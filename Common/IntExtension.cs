using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Int
{
    public static class IntExtension
    {
        private static Random random = new Random();

        public static int GetRandom(this int @this)
        {
            return random.Next(0, @this);
        }
    }
}
