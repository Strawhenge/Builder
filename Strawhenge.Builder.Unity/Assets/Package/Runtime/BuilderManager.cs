using PlasticGui.WorkspaceWindow.Open;
using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Builder.Unity.ScriptableObjects;
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
        readonly IBlueprintScriptableObjectMenu _menu;

        public BuilderManager(
            IBuildItemSelector buildItemSelector,
            Camera camera,
            ILayersAccessor layersAccessor,
            ExistingBlueprintManager existingBlueprintManager,
            ExistingBlueprintFactory existingBlueprintFactory,
            IBuilderManagerUI builderManagerUI,
            IBlueprintScriptableObjectMenu menu
            )
        {
            _buildItemSelector = buildItemSelector;
            _camera = camera;
            _layersAccessor = layersAccessor;
            _existingBlueprintManager = existingBlueprintManager;
            _existingBlueprintFactory = existingBlueprintFactory;
            _builderManagerUI = builderManagerUI;
            _menu = menu;
        }

        public void On()
        {
            MarkerLayersOn();
            ItemSelectorOn();
            ManagerUIOn();
        }

        public void Off()
        {
            ManagerUIOff();
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
            ManagerUIOff();
            ItemSelectorOff();

            _existingBlueprintManager.Set(
                _existingBlueprintFactory.Create(item),
                callback: OnExistingItemPlaced);
        }

        void OnExistingItemPlaced()
        {
            ManagerUIOn();
            ItemSelectorOn();
        }

        void ItemSelectorOff()
        {
            _buildItemSelector.Select -= OnBuildItemSelected;
            _buildItemSelector.Disable();
        }

        void ManagerUIOn()
        {
            _builderManagerUI.Enable();
            _builderManagerUI.ExitBuilder += Off;
            _builderManagerUI.OpenMenu += OpenMenu;
        }

        void OpenMenu()
        {
            ItemSelectorOff();
            ManagerUIOff();
            _menu.Open();
        }

        void ManagerUIOff()
        {
            _builderManagerUI.ExitBuilder -= Off;
            _builderManagerUI.Disable();
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

    public interface IBlueprintScriptableObjectMenu
    {
        event Action<BlueprintScriptableObject> Select;
        event Action Exit;

        void Open();

        void Close();
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
