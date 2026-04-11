using Strawhenge.Common.Unity.Camera;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class MarkersToggle
    {
        readonly Camera _camera;
        readonly ILayers _layers;

        public MarkersToggle(ICameraAccessor cameraAccessor, ILayers layers)
        {
            _camera = cameraAccessor.GetCamera();
            _layers = layers;
        }

        public MarkersToggle(Camera camera, ILayers layers)
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