using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools.Utils;

namespace Strawhenge.Builder.Unity.Tests
{
    public static class UnityAssert
    {
        public static void AreEqual(Vector3 expected, Vector3 actual) =>
            Assert.That(actual, Is.EqualTo(expected).Using(Vector3EqualityComparer.Instance));

        public static void AreEqual(Vector3 expected, Vector3 actual, float allowedError) =>
            Assert.That(actual, Is.EqualTo(expected).Using(new Vector3EqualityComparer(allowedError)));

        public static void AreEqual(Quaternion expected, Quaternion actual) =>
            Assert.That(actual, Is.EqualTo(expected).Using(QuaternionEqualityComparer.Instance));

        public static void AreEqual(Quaternion expected, Quaternion actual, float allowedError) =>
            Assert.That(actual, Is.EqualTo(expected).Using(new QuaternionEqualityComparer(allowedError)));
    }
}
