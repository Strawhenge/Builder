using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public interface ICameraController
    {
        void FocusOnBuildItem(Transform anchor);
       
        void FocusOnSnapPoint(Transform anchor);

        void Unfocus();
    }
}