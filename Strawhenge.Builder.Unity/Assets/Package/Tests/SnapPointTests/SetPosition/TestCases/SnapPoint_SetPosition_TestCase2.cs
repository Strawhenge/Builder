using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests.UnitTests
{
    public class SnapPoint_SetPosition_TestCase2 : SnapPoint_SetPosition_Tests
    {
        protected override Vector3 PositionToSet => Vector3.zero;

        protected override Vector3 ExpectedRootPosition => new Vector3(0, 0, -1);

        protected override GameObject CreateSubject()
        {
            var root = GameObjectCreator.Create();

            return GameObjectCreator.Create(
                position: new Vector3(0, 0, 1),
                parent: root.transform);
        }
    }
}
