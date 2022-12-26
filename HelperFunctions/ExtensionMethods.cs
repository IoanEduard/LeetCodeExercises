using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _HelperFunctions
{
    public static class ExtensionMethods
    {
        public static void InsertOrIncrement<TKey>(this Dictionary<TKey, int> dictionary, TKey key)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key]++;
            }
            else
            {
                dictionary.Add(key, 1);
            }
        }

        public static void RemoveOrDecrement<TKey>(this Dictionary<TKey, int> dictionary, TKey key)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key]--;
            }

            if (dictionary[key] < 1)
                dictionary.Remove(key);

        }
    }
}
