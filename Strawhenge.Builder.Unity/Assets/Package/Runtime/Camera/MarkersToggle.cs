using Strawhenge.Builder.Unity.Layers;
using Strawhenge.Common.Unity.Camera;

namespace Strawhenge.Builder.Unity.Camera
{
    public class MarkersToggle
    {
        readonly UnityEngine.Camera _camera;
        readonly ILayers _layers;

        public MarkersToggle(ICameraAccessor cameraAccessor, ILayers layers)
        {
            _camera = cameraAccessor.GetCamera();
            _layers = layers;
        }

        public MarkersToggle(UnityEngine.Camera camera, ILayers layers)
        {
            _camera = camera;
            _layers = layers;
        }

        public void On()
        {
            foreach (var layer in _layers.MarkerLayers)
            {
                _camera.cullingMask |= 1 << layer;
            }
        }

        public void Off()
        {
            foreach (var layer in _layers.MarkerLayers)
            {
                _camera.cullingMask &= ~(1 << layer);
            }
        }
    }
}