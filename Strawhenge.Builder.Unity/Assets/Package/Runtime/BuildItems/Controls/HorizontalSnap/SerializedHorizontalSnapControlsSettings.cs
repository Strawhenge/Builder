using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    [Serializable]
    public class SerializedHorizontalSnapControlsSettings : IHorizontalSnapControlsSettings
    {
        [SerializeField] float _tiltSpeed = DefaultHorizontalSnapControlsSettings.TiltSpeed;
        [SerializeField] float _slideSpeed = DefaultHorizontalSnapControlsSettings.SlideSpeed;

        public float TiltSpeed => _tiltSpeed;

        public float SlideSpeed => _slideSpeed;
    }
}