using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.BuildItems.SlotSettings
{
    public interface IWallSideSlotSettings
    {
        bool CanRotate { get; }

        IEnumerable<float> PresetAngles { get; }
    }
}