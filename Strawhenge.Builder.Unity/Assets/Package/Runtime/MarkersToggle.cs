using Strawhenge.Common.Unity.Camera;

namespace Strawhenge.Builder.Unity
{
    public class MarkersToggle
    {
        readonly ICameraAccessor _cameraAccessor;
        readonly ILayers _layers;

        public MarkersToggle(ICameraAccessor cameraAccessor, ILayers layers)
        {
            _cameraAccessor = cameraAccessor;
            _layers = layers;
        }

        public void On()
        {
            var camera = _cameraAccessor.GetCamera();

            foreach (var layer in _layers.MarkerLayers)
            {
                camera.cullingMask |= 1 << layer;
            }
        }

        public void Off()
        {
            var camera = _cameraAccessor.GetCamera();

            foreach (var layer in _layers.MarkerLayers)
            {
                camera.cullingMask &= ~(1 << layer);
            }
        }
    }
}