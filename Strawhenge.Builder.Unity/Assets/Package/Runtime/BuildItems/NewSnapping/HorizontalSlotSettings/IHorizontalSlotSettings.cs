using Strawhenge.Common.Ranges;

namespace Strawhenge.Builder.Unity.BuildItems.NewSnapping
{
    public interface IHorizontalSlotSettings
    {
        bool CanFlip { get; }

        FloatRange TiltRange { get; }
    }
}