using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests.UnitTests
{
    public class SnapPoint_SetRotation_TestCase6 : SnapPoint_SetRotation_Tests
    {
        protected override Quaternion RotationToSet => new Quaternion(-0.317548245f, -0.0760280788f, 0.207330257f, 0.922169745f);

        protected override Quaternion ExpectedRootRotation => new Quaternion(-0.308447093f, -0.221867353f, 0.417969346f, 0.825189054f);

        protected override Vector3 ExpectedRootPosition => new Vector3(0.447847f, -0.8266762f, -0.1083221f);

        protected override GameObject CreateSubject()
        {
            var root = GameObjectCreator.Create();

            return GameObjectCreator.Create(
                position: Vector3.right,
                rotation: new Quaternion(0.0366256535f, 0.210636839f, -0.1673491f, 0.962437034f),
                parent: root.transform);
        }
    }
}
