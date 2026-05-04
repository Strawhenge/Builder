using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests.SnapPointTests.SetRotation.TestCases
{
    public class SetRotationChildIdentity : BaseSnapPointSetRotationTest
    {
        protected override Quaternion RotationToSet => new Quaternion(0, 0, 0, 1);

        protected override Quaternion ExpectedRootRotation => new Quaternion(0, 0, 0, 1);

        protected override Vector3 ExpectedRootPosition => Vector3.zero;

        protected override GameObject CreateSubject()
        {
            var root = GameObjectCreator.Create();

            return GameObjectCreator.Create(parent: root.transform);
        }
    }
}
