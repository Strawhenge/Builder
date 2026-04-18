using UnityEngine;

namespace Strawhenge.Builder.Unity.Camera
{
    public abstract class CameraControllerScript : MonoBehaviour
    {
        public abstract ICameraController CameraController { get; }
    }
}