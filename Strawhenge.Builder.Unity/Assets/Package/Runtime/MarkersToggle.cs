using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class MarkersToggle
    {
        readonly Camera _camera;
        readonly ILayersAccessor _layers;

        public MarkersToggle(Camera camera, ILayersAccessor layers)
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