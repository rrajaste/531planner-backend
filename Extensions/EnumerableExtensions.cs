using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsEmptyOrNull<T>(this IEnumerable<T>? enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }
    }
}