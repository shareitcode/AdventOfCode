using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Utils
{
	public static class CollectionExtension
	{
		public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection) => collection == null || !collection.Any();
	}
}