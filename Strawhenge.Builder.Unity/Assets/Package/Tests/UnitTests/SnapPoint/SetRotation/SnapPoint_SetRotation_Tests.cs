using NUnit.Framework;
using Strawhenge.Builder.Unity.BuildItems.Snapping;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests.UnitTests
{
    public abstract class SnapPoint_SetRotation_Tests
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
        public void SetRotation_ShouldHaveExpectedRotation()
        {
            SetRotation();

            UnityAssert.AreEqual(RotationToSet, transform.rotation);
        }

        [Test]
        public void SetRotation_PositionShouldNotHaveChanged()
        {
            var position = transform.position;

            SetRotation();

            UnityAssert.AreEqual(position, transform.position);
        }

        [Test]
        public void SetRotation_RootShouldHaveExpectedRotation()
        {
            SetRotation();

            UnityAssert.AreEqual(ExpectedRootRotation, transform.root.rotation);
        }

        [Test]
        public void SetRotation_RootShouldBeInExpectedPosition()
        {
            SetRotation();

            UnityAssert.AreEqual(ExpectedRootPosition, transform.root.position);
        }

        protected abstract Quaternion RotationToSet { get; }

        protected abstract Quaternion ExpectedRootRotation { get; }

        protected abstract Vector3 ExpectedRootPosition { get; }

        protected abstract GameObject CreateSubject();

        void SetRotation()
        {
            sut.SetRotation(RotationToSet);
        }
    }
}
