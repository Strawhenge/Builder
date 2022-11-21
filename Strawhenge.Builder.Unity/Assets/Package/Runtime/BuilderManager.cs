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
        readonly ExistingBlueprintManager _existingBlueprintManager;
        readonly ExistingBlueprintFactory _existingBlueprintFactory;
        readonly IBuilderManagerUI _builderManagerUI;

        public BuilderManager(
            IBuildItemSelector buildItemSelector,
            Camera camera,
            ILayersAccessor layersAccessor,
            ExistingBlueprintManager existingBlueprintManager,
            ExistingBlueprintFactory existingBlueprintFactory,
            IBuilderManagerUI builderManagerUI)
        {
            _buildItemSelector = buildItemSelector;
            _camera = camera;
            _layersAccessor = layersAccessor;
            _existingBlueprintManager = existingBlueprintManager;
            _existingBlueprintFactory = existingBlueprintFactory;
            _builderManagerUI = builderManagerUI;
        }

        public void On()
        {
            MarkerLayersOn();
            ItemSelectorOn();

            _builderManagerUI.Enable();
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

            _existingBlueprintManager.Set(
                _existingBlueprintFactory.Create(item));
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

    public interface IBuilderManagerUI
    {
        event Action ExitBuilder;
        event Action OpenMenu;

        void Enable();

        void Disable();
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
