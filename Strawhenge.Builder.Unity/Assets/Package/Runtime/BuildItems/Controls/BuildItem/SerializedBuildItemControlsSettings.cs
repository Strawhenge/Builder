using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    [Serializable]
    public class SerializedBuildItemControlsSettings : IBuildItemControlsSettings
    {
        [SerializeField] float _moveSpeed = DefaultBuildItemControlsSettings.MoveSpeed;
        [SerializeField] float _turnSpeed = DefaultBuildItemControlsSettings.TurnSpeed;

        public float MoveSpeed => _moveSpeed;

        public float TurnSpeed => _turnSpeed;
    }
}