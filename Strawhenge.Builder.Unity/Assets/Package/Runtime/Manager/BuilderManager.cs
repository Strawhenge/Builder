using Strawhenge.Builder.Unity.Blueprints;
using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Builder.Unity.ScriptableObjects;

namespace Strawhenge.Builder.Unity
{
    public partial class BuilderManager
    {
        readonly MarkersToggle _markers;
        readonly IBlueprintFactory _blueprintFactory;

        readonly SelectingExistingItem _selectingExistingItem;
        readonly ManagingExistingBlueprint _managingExistingBlueprint;
        readonly ManagingNewBlueprint _managingNewBlueprint;
        readonly MenuOpen _menuOpen;

        IState _currentState;

        public BuilderManager(
            IBuildItemScriptSelector buildItemSelector,
            MarkersToggle markers,
            ExistingBlueprintManager existingBlueprintManager,
            BlueprintManager blueprintManager,
            IBlueprintFactory blueprintFactory,
            IBuilderManagerUI builderManagerUI,
            IBlueprintScriptableObjectMenu menu
        )
        {
            _markers = markers;
            _blueprintFactory = blueprintFactory;

            _selectingExistingItem = new SelectingExistingItem(
                builderManagerUI,
                buildItemSelector,
                OnExistingBuildItemSelected,
                OnMenuOpen,
                OnExitBuilder);

            _managingExistingBlueprint =
                new ManagingExistingBlueprint(existingBlueprintManager, OnManageExistingItemEnded);
            _managingNewBlueprint = new ManagingNewBlueprint(blueprintManager, OnManageNewItemEnded);
            _menuOpen = new MenuOpen(menu, OnBlueprintSelectedFromMenu, OnMenuClosed);
        }

        public bool IsOn { get; private set; }

        public void On()
        {
            if (IsOn) return;
            IsOn = true;

            _markers.On();
            SetState(_selectingExistingItem);
        }

        public void Off()
        {
            if (!IsOn) return;
            IsOn = false;

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
            _managingExistingBlueprint.Blueprint = _blueprintFactory.Create(script);
            SetState(_managingExistingBlueprint);
        }

        void OnBlueprintSelectedFromMenu(BlueprintScriptableObject scriptableObject)
        {
            _managingNewBlueprint.Blueprint = _blueprintFactory.Create(scriptableObject);
            SetState(_managingNewBlueprint);
        }

        void OnManageExistingItemEnded() => SetState(_selectingExistingItem);

        void OnManageNewItemEnded() => SetState(_menuOpen);

        void OnMenuOpen() => SetState(_menuOpen);

        void OnMenuClosed() => SetState(_selectingExistingItem);

        void OnExitBuilder() => Off();
    }
}