using Strawhenge.Common.Ranges;

namespace Strawhenge.Builder.Unity.BuildItems.SlotSettings
{
    public interface IFloorEdgeSlotSettings
    {
        bool CanFlip { get; }

        FloatRange TiltRange { get; }
    }
}