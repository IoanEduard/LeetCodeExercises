using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelperFunctions
{
    public static class Utils
    {
        public static char[] wovewls = new char[] { 'a', 'e', 'i', 'o', 'u' };
        public static char[] wovewlsUpperCase = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

        public static int[] AllIntegers()
        {
            var ints = Enumerable.Range(0, int.MaxValue / 20);

            return ints.ToArray();
        }
    }
}