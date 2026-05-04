using Strawhenge.Builder.Unity.BuildItems.Snapping.Triggers;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    class VerticalSnapContainer
    {
        readonly SnapPoint _snapPoint;
        readonly CollisionTracker _tracker;
        readonly float _slotLength;

        public VerticalSnapContainer(SnapPoint snapPoint, CollisionTracker tracker, float slotLength)
        {
            _snapPoint = snapPoint;
            _tracker = tracker;
            _slotLength = slotLength;
        }

        public IEnumerable<VerticalSnap> GetAvailableSnaps()
        {
            foreach (var snapSlotScript in _tracker.GetCollidingWith<VerticalSlotScript>())
                yield return Map(snapSlotScript.Slot);
        }

        VerticalSnap Map(VerticalSlot snapSlot) =>
            new(
                _snapPoint,
                snapSlot.Anchor,
                snapSlot.CanRotate,
                snapSlot.PresetAngles,
                SlideRangeHelper.GetRange(snapSlot.SlideLength, _slotLength));
    }
}

