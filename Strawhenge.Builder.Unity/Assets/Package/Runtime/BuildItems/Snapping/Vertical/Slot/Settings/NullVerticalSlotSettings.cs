using System;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    class NullVerticalSlotSettings : IVerticalSlotSettings
    {
        public static IVerticalSlotSettings Instance { get; } = new NullVerticalSlotSettings();

        NullVerticalSlotSettings()
        {
        }

        public bool CanRotate => false;

        public IEnumerable<float> PresetAngles => Array.Empty<float>();
    }
}

