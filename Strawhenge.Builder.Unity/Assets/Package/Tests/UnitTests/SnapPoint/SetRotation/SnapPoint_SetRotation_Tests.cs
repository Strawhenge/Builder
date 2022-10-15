using NUnit.Framework;
using Strawhenge.Builder.Unity.BuildItems.Snapping;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests.UnitTests
{
    public abstract class SnapPoint_SetRotation_Tests
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
        public void SetRotation_ShouldHaveExpectedRotation()
        {
            SetRotation();

            UnityAssert.AreEqual(RotationToSet, _transform.rotation);
        }

        [Test]
        public void SetRotation_PositionShouldNotHaveChanged()
        {
            var position = _transform.position;

            SetRotation();

            UnityAssert.AreEqual(position, _transform.position);
        }

        [Test]
        public void SetRotation_RootShouldHaveExpectedRotation()
        {
            SetRotation();

            UnityAssert.AreEqual(ExpectedRootRotation, _transform.root.rotation);
        }

        [Test]
        public void SetRotation_RootShouldBeInExpectedPosition()
        {
            SetRotation();

            UnityAssert.AreEqual(ExpectedRootPosition, _transform.root.position);
        }

        protected abstract Quaternion RotationToSet { get; }

        protected abstract Quaternion ExpectedRootRotation { get; }

        protected abstract Vector3 ExpectedRootPosition { get; }

        protected abstract GameObject CreateSubject();

        void SetRotation()
        {
            _sut.SetRotation(RotationToSet);
        }
    }
}
