using System;
using System.Linq;
using System.Collections.Generic;

public static class IEnumerableExtension
{
    public static IEnumerable<Tuple<T, int>> WithIndex<T>(this IEnumerable<T> source)
    {
        return source.Select((t, i) => Tuple.Create(t, i));
    }
}
