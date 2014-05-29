using System;
using System.Collections.Generic;
using System.Linq;

namespace LibKo.Utilties
{
    public static class Enumerables
    {
        /// <summary>
        /// Tries to get an object of type T at specified index. If out of range, default(T) is returned
        /// </summary>
        public static T TryGet<T>(this IEnumerable<T> arr, int index)
        {
            if (arr.Count() > index)
            {
                return arr.Skip(index).Take(1).First();
            }
            return default(T);
        }
        /// <summary>
        /// Tries to get an object of type T at specified index. If out of range, default(T) is returned
        /// </summary>
        public static IEnumerable<T> TryGetRange<T>(this IEnumerable<T> arr, int index, int count)
        {
            if (arr.Count() > index)
            {
                return arr.Skip(index).Take(count);
            }
            return null;
        }

        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
        {
            var rnd = new Random();
            return source.OrderBy<T, int>((item) => rnd.Next());
        }
    }
}
