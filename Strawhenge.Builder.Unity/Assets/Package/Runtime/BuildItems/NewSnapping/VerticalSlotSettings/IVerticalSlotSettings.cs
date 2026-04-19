using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.BuildItems.NewSnapping
{
    public interface IVerticalSlotSettings
    {
        bool CanRotate { get; }

        IEnumerable<float> PresetAngles { get; }
    }
}