using Strawhenge.Builder.Unity.Monobehaviours;
using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class BuilderManager
    {
        readonly IBuildItemSelector _buildItemSelector;
        readonly Camera _camera;
        readonly ILayersAccessor _layersAccessor;

        public BuilderManager(
            IBuildItemSelector buildItemSelector,
            Camera camera,
            ILayersAccessor layersAccessor)
        {
            _buildItemSelector = buildItemSelector;
            _camera = camera;
            _layersAccessor = layersAccessor;
        }

        public void On()
        {
            MarkerLayersOn();
            ItemSelectorOn();
        }

        public void Off()
        {
            MarkerLayersOff();
            ItemSelectorOff();
        }

        void ItemSelectorOn()
        {
            _buildItemSelector.Select += OnBuildItemSelected;
            _buildItemSelector.Enable();
        }

        void OnBuildItemSelected(BuildItemScript item)
        {
            ItemSelectorOff();
        }

        void ItemSelectorOff()
        {
            _buildItemSelector.Select -= OnBuildItemSelected;
            _buildItemSelector.Disable();
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

    public interface IBuildItemSelector
    {
        event Action<BuildItemScript> Select;

        void Enable();

        void Disable();
    }
}
