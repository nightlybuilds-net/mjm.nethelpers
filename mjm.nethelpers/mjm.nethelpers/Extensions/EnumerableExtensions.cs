using System.Collections.Generic;
using System.Linq;

namespace mjm.nethelpers.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Extension for List.IsNullOrEmpty
        /// </summary>
        /// <param name="text"></param>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.IsNull() || !enumerable.Any();
        }

        /// <summary>
        /// Extension for List.IsEmpty
        /// </summary>
        /// <param name="text"></param>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
        {
            return !enumerable.Any();
        }
    }
}