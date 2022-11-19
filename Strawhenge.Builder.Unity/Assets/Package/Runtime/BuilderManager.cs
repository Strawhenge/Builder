using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class BuilderManager
    {
        readonly Camera _camera;
        readonly ILayersAccessor _layersAccessor;

        public BuilderManager(Camera camera, ILayersAccessor layersAccessor)
        {
            _camera = camera;
            _layersAccessor = layersAccessor;
        }

        public void On()
        {
            MarkerLayersOn();
        }

        public void Off()
        {
            MarkerLayersOff();
        }

        void MarkerLayersOn()
        {
            foreach (var layer in _layersAccessor.MarkerLayers)
            {
                _camera.cullingMask |= 1 << layer;
            }
        }

        void MarkerLayersOff()
        {
            foreach (var layer in _layersAccessor.MarkerLayers)
            {
                _camera.cullingMask &= ~(1 << layer);
            }
        }
    }

    public interface ILayersAccessor
    {
        int[] MarkerLayers { get; }
    }
}
