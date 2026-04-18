using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    static class ObjectHelper
    {
        public static void Destroy(Object @object)
        {
# if UNITY_EDITOR
            Object.DestroyImmediate(@object);
#else
            Object.Destroy(@object);
#endif
        }
    }
}