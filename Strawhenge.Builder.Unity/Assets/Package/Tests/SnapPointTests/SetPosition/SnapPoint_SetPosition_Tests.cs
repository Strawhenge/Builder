using NUnit.Framework;
using Strawhenge.Builder.Unity.BuildItems.Snapping;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests.UnitTests
{
    public abstract class SnapPoint_SetPosition_Tests
    {
        Transform _transform;
        SnapPoint _sut;

        [SetUp]
        public void SetUp()
        {
            _transform = CreateSubject().transform;
            _sut = new SnapPoint(_transform);
        }

        [Test]
        public void SetPosition_ShouldBeInPosition()
        {
            SetPosition();

            Assert.AreEqual(PositionToSet, _transform.position);
        }

        [Test]
        public void SetPosition_RootShouldBeInExpectedPosition()
        {
            SetPosition();

            Assert.AreEqual(ExpectedRootPosition, _transform.root.position);
        }

        [Test]
        public void SetPosition_RotationShouldNotChange()
        {
            var rotation = _transform.rotation;

            SetPosition();

            Assert.AreEqual(rotation, _transform.rotation);
        }

        [Test]
        public void SetPosition_RootRotationShouldNotChange()
        {
            var rotation = _transform.root.rotation;

            SetPosition();

            Assert.AreEqual(rotation, _transform.root.rotation);
        }

        protected abstract Vector3 PositionToSet { get; }

        protected abstract Vector3 ExpectedRootPosition { get; }

        protected abstract GameObject CreateSubject();

        void SetPosition()
        {
            _sut.SetPosition(PositionToSet);
        }
    }
}