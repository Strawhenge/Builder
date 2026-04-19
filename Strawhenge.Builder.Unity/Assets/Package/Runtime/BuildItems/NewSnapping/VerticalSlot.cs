using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.NewSnapping
{
    class VerticalSlot
    {
        public VerticalSlot(Transform anchor, float slideLength, bool canRotate, IEnumerable<float> presetAngles)
        {
            Anchor = anchor;
            SlideLength = slideLength;
            CanRotate = canRotate;
            PresetAngles = presetAngles;
        }

        public Transform Anchor { get; }

        public bool CanRotate { get; }

        public IEnumerable<float> PresetAngles { get; }

        public float SlideLength { get; }
    }
}

