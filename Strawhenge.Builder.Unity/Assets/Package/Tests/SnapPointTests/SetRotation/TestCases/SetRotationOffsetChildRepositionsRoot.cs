using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests.SnapPointTests.SetRotation.TestCases
{
    public class SetRotationOffsetChildRepositionsRoot : BaseSnapPointSetRotationTest
    {
        protected override Quaternion RotationToSet => new Quaternion(0, 0.707106829f, 0, 0.707106829f);

        protected override Quaternion ExpectedRootRotation => new Quaternion(0, 0.707106829f, 0, 0.707106829f);

        protected override Vector3 ExpectedRootPosition => new Vector3(1, 0, 1);

        protected override GameObject CreateSubject()
        {
            var root = GameObjectCreator.Create();

            return GameObjectCreator.Create(
                position: Vector3.right,
                parent: root.transform);
        }
    }
}
