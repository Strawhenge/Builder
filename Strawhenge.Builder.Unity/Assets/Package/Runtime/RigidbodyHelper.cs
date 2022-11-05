using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public static class RigidbodyHelper
    {
        // ReSharper disable BitwiseOperatorOnEnumWithoutFlags
        // These ARE flags, but they are missing the [Flags] attribute in the Unity library.
        public const RigidbodyConstraints FreezeAllButRotationY =
            RigidbodyConstraints.FreezePosition |
            RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezeRotationZ;
        // ReSharper restore BitwiseOperatorOnEnumWithoutFlags
    }
}