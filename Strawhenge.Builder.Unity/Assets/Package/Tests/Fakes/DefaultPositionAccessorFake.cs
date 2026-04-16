using Strawhenge.Builder.Unity.BuildItems;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests.Fakes
{
    class DefaultPositionAccessorFake : IDefaultPositionAccessor
    {
        public Vector3 Position { get; set; }

        public Quaternion Rotation { get; set; }

        public Vector3 GetPosition() => Position;

        public Quaternion GetRotation() => Rotation;
    }
}