using Strawhenge.Common.Ranges;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    static class SlideRangeHelper
    {
        internal static FloatRange GetRange(float snapLength, float slotLength)
        {
            var length = (snapLength + slotLength) / 2;
            return new FloatRange(-length, length);
        }
    }
}