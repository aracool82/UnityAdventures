using System.Collections.Generic;

namespace _Project_L1.Scripts.Utils
{
    public static class DictionaryExtensions
    {
        public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, IEnumerable<KeyValuePair<TKey, TValue>> items)
        {
            foreach (var item in items)
                dictionary[item.Key] = item.Value;
        }
    }
}