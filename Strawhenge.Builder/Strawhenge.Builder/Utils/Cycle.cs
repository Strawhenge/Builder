using System;
using System.Collections.Generic;
using System.Linq;

namespace Strawhenge.Builder
{
    public class Cycle<T>
    {
        readonly T[] _all;

        int _currentIndex;

        public Cycle(T initial, params T[] others) : this(initial, (IEnumerable<T>)others)
        {
        }

        public Cycle(T initial, IEnumerable<T> others)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            if (others == null) throw new ArgumentNullException(nameof(others));

            _currentIndex = 0;

            _all = new[] { initial }
                .Concat(others)
                .ToArray();
        }

        public T Current => _all[_currentIndex];

        public T Next()
        {
            _currentIndex++;

            if (_currentIndex >= _all.Length)
                _currentIndex = 0;

            return Current;
        }

        public T Previous()
        {
            _currentIndex--;

            if (_currentIndex < 0)
                _currentIndex = _all.Length - 1;

            return Current;
        }

        public IEnumerable<T> AsEnumerable() => _all;
    }
}
