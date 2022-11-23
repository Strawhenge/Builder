using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Builder.Unity.ScriptableObjects;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public partial class BuilderManager
    {
        readonly MarkersToggle _markers;
        readonly ExistingBlueprintFactory _existingBlueprintFactory;
        readonly SelectingExistingItem _selectingExistingItem;
        readonly ManagingExistingBlueprint _managingExistingBlueprint;
        readonly MenuOpen _menuOpen;

        IState _currentState;

        public BuilderManager(
            IBuildItemScriptSelector buildItemSelector,
            MarkersToggle markers,
            ExistingBlueprintManager existingBlueprintManager,
            ExistingBlueprintFactory existingBlueprintFactory,
            IBuilderManagerUI builderManagerUI,
            IBlueprintScriptableObjectMenu menu
            )
        {
            _markers = markers;
            _existingBlueprintFactory = existingBlueprintFactory;

            _selectingExistingItem = new SelectingExistingItem(
                builderManagerUI,
                buildItemSelector,
                OnExistingBuildItemSelected,
                OnMenuOpen,
                OnExitBuilder);

            _managingExistingBlueprint = new ManagingExistingBlueprint(existingBlueprintManager, OnManageExistingItemEnded);
            _menuOpen = new MenuOpen(menu, _ => { }, OnMenuClosed);
        }

        public void On()
        {
            _markers.On();
            SetState(_selectingExistingItem);
        }

        public void Off()
        {
            SetState(null);
            _markers.Off();
        }

        void SetState(IState state)
        {
            _currentState?.End();
            _currentState = state;
            _currentState?.Begin();
        }

        void OnExistingBuildItemSelected(BuildItemScript script)
        {
            _managingExistingBlueprint.Blueprint = _existingBlueprintFactory.Create(script);
            SetState(_managingExistingBlueprint);
        }

        void OnManageExistingItemEnded() => SetState(_selectingExistingItem);

        void OnMenuOpen() => SetState(_menuOpen);

        void OnMenuClosed() => SetState(_selectingExistingItem);

        void OnExitBuilder() => Off();
    }
}
