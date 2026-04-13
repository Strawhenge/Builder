using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    [Serializable]
    public class BuildItemControlsSettings
    {
        [SerializeField] float _moveSpeed = 5;
        [SerializeField] float _turnSpeed = 2;

        public float MoveSpeed => _moveSpeed;

        public float TurnSpeed => _turnSpeed;
    }
}