using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests.SnapPointTests.SetPosition
{
    public class SetPositionChildAtOrigin : BaseSnapPointSetPositionTest
    {
        protected override Vector3 PositionToSet => Vector3.zero;

        protected override Vector3 ExpectedRootPosition => Vector3.zero;

        protected override GameObject CreateSubject()
        {
            var root = GameObjectCreator.Create();

            return GameObjectCreator.Create(parent: root.transform);
        }
    }
}
