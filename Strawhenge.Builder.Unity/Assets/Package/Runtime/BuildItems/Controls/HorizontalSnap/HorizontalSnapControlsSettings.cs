using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    [Serializable]
    public class HorizontalSnapControlsSettings
    {
        [SerializeField] float _tiltSpeed = 1;
        [SerializeField] float _slideSpeed = 0.1f;

        public float TiltSpeed => _tiltSpeed;

        public float SlideSpeed => _slideSpeed;
    }
}