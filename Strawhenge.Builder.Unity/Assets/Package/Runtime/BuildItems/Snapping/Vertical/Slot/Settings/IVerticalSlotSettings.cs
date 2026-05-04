using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    public interface IVerticalSlotSettings
    {
        bool CanRotate { get; }

        IEnumerable<float> PresetAngles { get; }
    }
}