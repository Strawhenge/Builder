using System;
using System.Collections.Generic;
using System.Linq;

namespace Strawhenge.Builder
{
    public class Cycle<T>
    {
        private readonly T[] all;

        private int currentIndex;

        public Cycle(T initial, params T[] others) : this(initial, (IEnumerable<T>)others)
        {
        }

        public Cycle(T initial, IEnumerable<T> others)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            if (others == null) throw new ArgumentNullException(nameof(others));

            currentIndex = 0;

            all = new T[] { initial }
                .Concat(others)
                .ToArray();
        }

        public T Current => all[currentIndex];

        public T Next()
        {
            currentIndex++;

            if (currentIndex >= all.Length)
                currentIndex = 0;

            return Current;
        }

        public T Previous()
        {
            currentIndex--;

            if (currentIndex < 0)
                currentIndex = all.Length - 1;

            return Current;
        }

        public IEnumerable<T> AsEnumerable() => all;
    }
}
