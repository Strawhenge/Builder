using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    [Serializable]
    public class VerticalSnapControlsSettings
    {
        [SerializeField] float _turnSpeed = 1;
        [SerializeField] float _slideSpeed = 0.1f;

        public float TurnSpeed => _turnSpeed;
        public float SlideSpeed => _slideSpeed;
    }
}