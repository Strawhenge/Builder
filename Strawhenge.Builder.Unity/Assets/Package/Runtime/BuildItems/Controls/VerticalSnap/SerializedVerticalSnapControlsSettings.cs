using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Controls.VerticalSnap
{
    [Serializable]
    public class SerializedVerticalSnapControlsSettings : IVerticalSnapControlsSettings
    {
        [SerializeField] float _turnSpeed = DefaultVerticalSnapControlsSettings.TurnSpeed;
        [SerializeField] float _slideSpeed = DefaultVerticalSnapControlsSettings.SlideSpeed;

        public float TurnSpeed => _turnSpeed;
        public float SlideSpeed => _slideSpeed;
    }
}