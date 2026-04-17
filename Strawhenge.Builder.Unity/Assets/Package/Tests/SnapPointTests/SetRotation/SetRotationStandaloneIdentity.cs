using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests.SnapPointTests.SetRotation
{
    public class SetRotationStandaloneIdentity : BaseSnapPointSetRotationTest
    {
        protected override Quaternion RotationToSet => new Quaternion(0, 0, 0, 1);

        protected override Quaternion ExpectedRootRotation => new Quaternion(0, 0, 0, 1);

        protected override Vector3 ExpectedRootPosition => Vector3.zero;

        protected override GameObject CreateSubject()
        {
            return GameObjectCreator.Create();
        }
    }
}
