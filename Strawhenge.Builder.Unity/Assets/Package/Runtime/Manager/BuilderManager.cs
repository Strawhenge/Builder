using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity.Blueprints;
using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Builder.Unity.Progress;
using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Builder.Unity.UI;
using System;
using UnityEngine;
using ILogger = Strawhenge.Common.Logging.ILogger;

namespace Strawhenge.Builder.Unity
{
    public partial class BuilderManager
    {
        readonly MarkersToggle _markers;
        readonly IBlueprintFactory _blueprintFactory;

        readonly ProgressManager _progressManager;

        readonly SelectingExistingItem _selectingExistingItem;
        readonly ManagingExistingBlueprint _managingExistingBlueprint;
        readonly ManagingNewBlueprint _managingNewBlueprint;
        readonly MenuOpen _menuOpen;

        IState _currentState;

        public BuilderManager(
            IComponentInventory componentInventory,
            IBuildItemSelector buildItemSelector,
            Camera camera,
            ICameraController cameraController,
            IDefaultPositionAccessor defaultPositionAccessor,
            IBuilderManagerUI builderManagerUI,
            IMenuView menu,
            IRecipeUI recipeUI,
            IScrapUI scrapUI,
            IBlueprintRepository blueprintRepository,
            IControlsSettings controlsSettings,
            ILayers layers,
            ILogger logger)
        {
            _markers = new MarkersToggle(camera, layers);

            var progressTracker = new BuilderProgressTracker(logger);
            _blueprintFactory = new BlueprintFactory(progressTracker, defaultPositionAccessor, logger);
            _progressManager = new ProgressManager(
                blueprintRepository,
                _blueprintFactory,
                progressTracker,
                logger);

            _selectingExistingItem = new SelectingExistingItem(
                builderManagerUI,
                buildItemSelector,
                OnExistingBuildItemSelected,
                OnMenuOpen,
                OnExitBuilder);

            var builderMenu = new BuilderMenu(menu);
            var scriptableObjectsMenu = new BlueprintScriptableObjectMenu(
                builderMenu,
                blueprintRepository);

            Controls = new Controls(controlsSettings);

            var buildItemController = new BuildItemController(
                cameraController,
                Controls.BuildItem,
                Controls.VerticalSnap,
                Controls.HorizontalSnap);

            var existingBlueprintManager = new ExistingBlueprintManager(
                componentInventory,
                buildItemController,
                scrapUI);

            var blueprintManager = new BlueprintManager(
                componentInventory,
                buildItemController,
                recipeUI);

            _managingExistingBlueprint =
                new ManagingExistingBlueprint(existingBlueprintManager, OnManageExistingItemEnded);
            _managingNewBlueprint = new ManagingNewBlueprint(blueprintManager, OnManageNewItemEnded);
            _menuOpen = new MenuOpen(scriptableObjectsMenu, OnBlueprintSelectedFromMenu, OnMenuClosed);
        }

        public event Action TurningOn;
        public event Action TurnedOff;

        public bool IsOn { get; private set; }

        public Controls Controls { get; }

        public void On()
        {
            if (IsOn) return;
            IsOn = true;

            TurningOn?.Invoke();
            _markers.On();
            SetState(_selectingExistingItem);
        }

        public void Off()
        {
            if (!IsOn) return;
            IsOn = false;

            SetState(null);
            _markers.Off();
            TurnedOff?.Invoke();
        }

        public void Import(BuilderProgressData data) => _progressManager.Import(data);

        public BuilderProgressData Export() => _progressManager.Export();

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