using UnityEngine;

namespace Strawhenge.Builder.Unity.Camera
{
    public interface ICameraController
    {
        void FocusOnBuildItem(Transform anchor);

        void FocusOnSnapPoint(Transform anchor);

        void Unfocus();
    }
}