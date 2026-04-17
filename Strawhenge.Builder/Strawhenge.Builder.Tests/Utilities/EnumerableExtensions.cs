using System.Collections.Generic;

namespace Strawhenge.Builder.Tests
{
    static class EnumerableExtensions
    {
        public static IEnumerable<T> Enumerate<T>(this T value)
        {
            yield return value;
        }
    }
}
