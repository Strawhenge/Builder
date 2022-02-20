using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests.UnitTests
{
    public class SnapPoint_SetRotation_TestCase5 : SnapPoint_SetRotation_Tests
    {
        protected override Quaternion RotationToSet => new Quaternion(0, 0.707106829f, 0, 0.707106829f);

        protected override Quaternion ExpectedRootRotation => new Quaternion(0, 0, 0, 1);

        protected override Vector3 ExpectedRootPosition => Vector3.zero;

        protected override GameObject CreateSubject()
        {
            var root = GameObjectCreator.Create();

            return GameObjectCreator.Create(
                position: Vector3.right,
                rotation: RotationToSet,
                parent: root.transform);
        }
    }
}
