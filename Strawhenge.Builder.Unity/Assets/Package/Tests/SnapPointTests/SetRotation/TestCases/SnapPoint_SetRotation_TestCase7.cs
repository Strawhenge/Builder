using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests.UnitTests
{
    public class SnapPoint_SetRotation_TestCase7 : SnapPoint_SetRotation_Tests
    {
        protected override Quaternion RotationToSet => new Quaternion(-0.1f, 0.8f, -0.1f, 0.6f);

        protected override Quaternion ExpectedRootRotation => new Quaternion(-0.1f, 0.8f, -0.1f, 0.6f);

        protected override Vector3 ExpectedRootPosition => Vector3.zero;

        protected override GameObject CreateSubject()
        {
            var root = GameObjectCreator.Create(
                position: Vector3.zero,
                rotation: new Quaternion(0, 0.8f, 0, 0.6f));

            var parent = GameObjectCreator.Create(
                position: Vector3.zero,
                rotation: new Quaternion(0, 0.8f, 0, 0.6f),
                parent: root.transform);

            return GameObjectCreator.Create(
                position: Vector3.zero,
                rotation: new Quaternion(0, 0.8f, 0, 0.6f),
                parent: parent.transform);
        }
    }
}
