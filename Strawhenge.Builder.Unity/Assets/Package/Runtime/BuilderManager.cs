using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Builder.Unity.ScriptableObjects;
using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class BuilderManager
    {
        readonly IBuildItemScriptSelector _buildItemSelector;
        readonly MarkersToggle _markers;
        readonly ExistingBlueprintManager _existingBlueprintManager;
        readonly ExistingBlueprintFactory _existingBlueprintFactory;
        readonly IBuilderManagerUI _builderManagerUI;
        readonly IBlueprintScriptableObjectMenu _menu;

        public BuilderManager(
            IBuildItemScriptSelector buildItemSelector,
            MarkersToggle markers,
            ExistingBlueprintManager existingBlueprintManager,
            ExistingBlueprintFactory existingBlueprintFactory,
            IBuilderManagerUI builderManagerUI,
            IBlueprintScriptableObjectMenu menu
            )
        {
            _buildItemSelector = buildItemSelector;
            _markers = markers;
            _existingBlueprintManager = existingBlueprintManager;
            _existingBlueprintFactory = existingBlueprintFactory;
            _builderManagerUI = builderManagerUI;
            _menu = menu;
        }

        public void On()
        {
            _markers.On();
            ItemSelectorOn();
            ManagerUIOn();
        }

        public void Off()
        {
            ManagerUIOff();
            ItemSelectorOff();
            _markers.Off();
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

    public interface IBuildItemScriptSelector
    {
        event Action<BuildItemScript> Select;

        void Enable();

        void Disable();
    }
}
