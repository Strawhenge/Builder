using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests.SnapPointTests.SetPosition
{
    public class SetPositionTranslatedOffsetChildRepositionsRoot : BaseSnapPointSetPositionTest
    {
        protected override Vector3 PositionToSet => new Vector3(0, 0, -1);

        protected override Vector3 ExpectedRootPosition => new Vector3(0, 0, -2);

        protected override GameObject CreateSubject()
        {
            var root = GameObjectCreator.Create(position: new Vector3(0, 0, 1));

            return GameObjectCreator.Create(
                position: new Vector3(0, 0, 2),
                parent: root.transform);
        }
    }
}
