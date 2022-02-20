using NUnit.Framework;
using Strawhenge.Builder.Unity.BuildItems.Snapping;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests.UnitTests
{
    public abstract class SnapPoint_SetPosition_Tests
    {
        Transform transform;
        SnapPoint sut;

        [SetUp]
        public void SetUp()
        {
            transform = CreateSubject().transform;
            sut = new SnapPoint(transform);
        }

        [Test]
        public void SetPosition_ShouldBeInPosition()
        {
            SetPosition();

            Assert.AreEqual(PositionToSet, transform.position);
        }

        [Test]
        public void SetPosition_RootShouldBeInExpectedPosition()
        {
            SetPosition();

            Assert.AreEqual(ExpectedRootPosition, transform.root.position);
        }

        [Test]
        public void SetPosition_RotationShouldNotChange()
        {
            var rotation = transform.rotation;

            SetPosition();

            Assert.AreEqual(rotation, transform.rotation);
        }

        [Test]
        public void SetPosition_RootRotationShouldNotChange()
        {
            var rotation = transform.root.rotation;

            SetPosition();

            Assert.AreEqual(rotation, transform.root.rotation);
        }

        protected abstract Vector3 PositionToSet { get; }

        protected abstract Vector3 ExpectedRootPosition { get; }

        protected abstract GameObject CreateSubject();

        void SetPosition()
        {
            sut.SetPosition(PositionToSet);
        }
    }
}
