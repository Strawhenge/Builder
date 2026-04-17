using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests.UnitTests
{
    public class SnapPoint_SetPosition_TestCase1 : SnapPoint_SetPosition_Tests
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
