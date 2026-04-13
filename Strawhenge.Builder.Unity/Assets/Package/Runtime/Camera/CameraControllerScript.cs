using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public abstract class CameraControllerScript : MonoBehaviour
    {
        public abstract ICameraController CameraController { get; }
    }
}