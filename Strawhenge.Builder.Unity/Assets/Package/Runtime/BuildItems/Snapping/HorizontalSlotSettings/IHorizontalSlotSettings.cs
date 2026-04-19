using Strawhenge.Common.Ranges;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    public interface IHorizontalSlotSettings
    {
        bool CanFlip { get; }

        FloatRange TiltRange { get; }
    }
}