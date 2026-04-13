using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Common.Ranges;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    static class SlideRangeHelper
    {
        internal static FloatRange GetRange<TSnap, TSnapSlotScript>(
            BaseSnapScript<TSnap, TSnapSlotScript> snap,
            BaseSlotScript slot) where TSnapSlotScript : MonoBehaviour
        {
            var snapLength = snap.GetSlideLength();

            if (!snapLength.HasValue)
                return FloatRange.Zero;

            var slotLength = slot.GetSlideLength();

            if (!slotLength.HasValue)
                return FloatRange.Zero;

            var length = (snapLength.Value + slotLength.Value) / 2;
            return new FloatRange(-length, length);
        }
    }
}