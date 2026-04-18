using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Progress
{
    [Serializable]
    public class SerializedBuildItemData : IBuildItemData
    {
        [SerializeField] string _name;
        [SerializeField] Vector3 _position;
        [SerializeField] Vector3 _rotation;

        public string Name => _name;

        public Vector3 Position => _position;

        public Quaternion Rotation => Quaternion.Euler(_rotation);
    }
}