using Strawhenge.Common.Ranges;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.NewSnapping
{
    class HorizontalSlot
    {
        public HorizontalSlot(Transform anchor, float slideLength, bool canFlip, FloatRange tiltRange)
        {
            Anchor = anchor;
            SlideLength = slideLength;
            CanFlip = canFlip;
            TiltRange = tiltRange;
        }

        public Transform Anchor { get; }

        public bool CanFlip { get; }

        public FloatRange TiltRange { get; }

        public float SlideLength { get; }
    }
}