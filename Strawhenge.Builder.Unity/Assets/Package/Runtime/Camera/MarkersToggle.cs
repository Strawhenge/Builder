using Strawhenge.Builder.Unity.Layers;

namespace Strawhenge.Builder.Unity.Camera
{
    class MarkersToggle
    {
        readonly UnityEngine.Camera _camera;
        readonly ILayers _layers;

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