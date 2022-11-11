using System;
using Strawhenge.Common.Ranges;

namespace Strawhenge.Builder
{
    public class SlideAmount
    {
        readonly FloatRange _range;
        float _currentAmount;

        public SlideAmount(float min, float max)
        {
            _range = new FloatRange(min, max);
        }

        public bool Slide(float amount, out float delta)
        {
            if (!CanSlide(amount))
            {
                delta = 0;
                return false;
            }

            var newAmount = _range.Clamp(_currentAmount + amount);
            delta = newAmount - _currentAmount;
            _currentAmount = newAmount;
            return true;
        }

        bool CanSlide(float amount)
        {
            if (amount == 0)
                return false;

            if (amount > 0 && Math.Abs(_currentAmount - _range.Max) < 0.001f)
                return false;

            if (amount < 0 && Math.Abs(_currentAmount - _range.Min) < 0.001f)
                return false;

            return true;
        }
    }
}