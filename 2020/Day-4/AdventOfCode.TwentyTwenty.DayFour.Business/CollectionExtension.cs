using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.TwentyTwenty.DayFour.Business
{
    public static class CollectionExtension
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection) => collection == null || !collection.Any();
    }
}