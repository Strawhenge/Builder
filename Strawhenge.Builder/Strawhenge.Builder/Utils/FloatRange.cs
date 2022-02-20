using System;

namespace Strawhenge.Builder
{
    public class FloatRange
    {
        public static FloatRange None => new FloatRange(0, 0);

        public static implicit operator FloatRange((float min, float max) range) =>
            new FloatRange(range.min, range.max);

        public static bool IsValidRange(float min, float max) => max.CompareTo(min) >= 0;

        public FloatRange(float min, float max)
        {
            if (!IsValidRange(min, max))
                throw new ArgumentException($"'{nameof(max)}' cannot be smaller than '{nameof(min)}'", nameof(max));

            Min = min;
            Max = max;
        }

        public float Max { get; }

        public float Min { get; }

        public bool IsInRange(float value) =>
            value.CompareTo(Min) >= 0 &&
            value.CompareTo(Max) <= 0;

        public float Clamp(float value)
        {
            if (value.CompareTo(Min) < 0)
                return Min;

            if (value.CompareTo(Max) > 0)
                return Max;

            return value;
        }
    }
}
