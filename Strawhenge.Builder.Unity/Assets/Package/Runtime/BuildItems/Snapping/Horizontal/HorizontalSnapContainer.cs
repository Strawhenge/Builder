using Strawhenge.Builder.Unity.BuildItems.Snapping.Triggers;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    class HorizontalSnapContainer
    {
        readonly SnapPoint _snapPoint;
        readonly CollisionTracker _tracker;
        readonly float _slotLength;

        public HorizontalSnapContainer(SnapPoint snapPoint, CollisionTracker tracker, float slotLength)
        {
            _snapPoint = snapPoint;
            _tracker = tracker;
            _slotLength = slotLength;
        }

        public IEnumerable<HorizontalSnap> GetAvailableSnaps()
        {
            foreach (var snapSlotScript in _tracker.GetCollidingWith<HorizontalSlotScript>())
                yield return Map(snapSlotScript.Slot);
        }

        HorizontalSnap Map(HorizontalSlot snapSlot) =>
            new(
                _snapPoint,
                snapSlot.Anchor,
                snapSlot.TiltRange,
                SlideRangeHelper.GetRange(snapSlot.SlideLength, _slotLength),
                snapSlot.CanFlip);
    }
}