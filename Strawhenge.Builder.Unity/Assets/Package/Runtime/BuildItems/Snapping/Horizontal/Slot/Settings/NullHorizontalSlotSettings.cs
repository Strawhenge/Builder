using Strawhenge.Common.Ranges;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    class NullHorizontalSlotSettings : IHorizontalSlotSettings
    {
        public static IHorizontalSlotSettings Instance { get; } = new NullHorizontalSlotSettings();

        NullHorizontalSlotSettings()
        {
        }

        public bool CanFlip => false;

        public FloatRange TiltRange => FloatRange.Zero;
    }
}

