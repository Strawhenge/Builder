using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity.Blueprints;
using Strawhenge.Builder.Unity.Blueprints.Repository;
using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.BuildItems.Controller;
using Strawhenge.Builder.Unity.BuildItems.Controls;
using Strawhenge.Builder.Unity.BuildItems.DefaultPosition;
using Strawhenge.Builder.Unity.BuildItems.Existing;
using Strawhenge.Builder.Unity.BuildItems.New;
using Strawhenge.Builder.Unity.BuildItems.Selector;
using Strawhenge.Builder.Unity.Camera;
using Strawhenge.Builder.Unity.Layers;
using Strawhenge.Builder.Unity.Progress;
using Strawhenge.Builder.Unity.UI;
using System;
using ILogger = Strawhenge.Common.Logging.ILogger;

namespace Strawhenge.Builder.Unity.Manager
{
    public partial class BuilderManager
    {
        readonly MarkersToggle _markers;
        readonly BuildableItemFactory _buildableItemFactory;
        readonly Manager.BuilderManager.SelectingExistingItem _selectingExistingItem;
        readonly Manager.BuilderManager.ManagingExistingBlueprint _managingExistingBlueprint;
        readonly Manager.BuilderManager.ManagingNewBlueprint _managingNewBlueprint;
        readonly Manager.BuilderManager.MenuOpen _menuOpen;

        IState _currentState;

        public BuilderManager(
            ComponentInventory componentInventory,
            IBuildItemSelector buildItemSelector,
            UnityEngine.Camera camera,
            ICameraController cameraController,
            IDefaultPositionAccessor defaultPositionAccessor,
            UIContainer uiContainer,
            IBlueprintRepository blueprintRepository,
            IControlsSettings controlsSettings,
            ILayers layers,
            ILogger logger)
        {
            _markers = new MarkersToggle(camera, layers);

            var progressTracker = new BuilderProgressTracker(logger);
            _buildableItemFactory = new BuildableItemFactory(progressTracker, defaultPositionAccessor, logger);
            Progress = new ProgressManager(
                blueprintRepository,
                _buildableItemFactory,
                progressTracker,
                logger);

            _selectingExistingItem = new Manager.BuilderManager.SelectingExistingItem(
                uiContainer.BuilderManagerUI,
                buildItemSelector,
                OnExistingBuildItemSelected,
                OnMenuOpen,
                OnExitBuilder);

            var builderMenu = new BuilderMenu(uiContainer.MenuView);
            var scriptableObjectsMenu = new BlueprintMenu(
                builderMenu,
                blueprintRepository);

            Controls = new Controls(controlsSettings);

            var buildItemController = new BuildItemController(
                cameraController,
                Controls.BuildItem,
                Controls.VerticalSnap,
                Controls.HorizontalSnap);

            var existingBlueprintManager = new ExistingBuildableItemManager(
                componentInventory,
                buildItemController,
                uiContainer.ScrapUI);

            var blueprintManager = new NewBuildableItemManager(
                componentInventory,
                buildItemController,
                uiContainer.RecipeUI);

            _managingExistingBlueprint =
                new Manager.BuilderManager.ManagingExistingBlueprint(existingBlueprintManager, OnManageExistingItemEnded);
            _managingNewBlueprint = new Manager.BuilderManager.ManagingNewBlueprint(blueprintManager, OnManageNewItemEnded);
            _menuOpen = new Manager.BuilderManager.MenuOpen(scriptableObjectsMenu, OnBlueprintSelectedFromMenu, OnMenuClosed);
        }

        public event Action TurningOn;
        public event Action TurnedOff;

        public bool IsOn { get; private set; }

        public Controls Controls { get; }

        public ProgressManager Progress { get; }

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

        void SetState(IState state)
        {
            _currentState?.End();
            _currentState = state;
            _currentState?.Begin();
        }

        void OnExistingBuildItemSelected(BuildItemScript script)
        {
            _managingExistingBlueprint.BuildableItem = _buildableItemFactory.Create(script);
            SetState(_managingExistingBlueprint);
        }

        void OnBlueprintSelectedFromMenu(IBlueprint scriptableObject)
        {
            _managingNewBlueprint.NewBuildableItem = _buildableItemFactory.Create(scriptableObject);
            SetState(_managingNewBlueprint);
        }

        void OnManageExistingItemEnded() => SetState(_selectingExistingItem);

        void OnManageNewItemEnded() => SetState(_menuOpen);

        void OnMenuOpen() => SetState(_menuOpen);

        void OnMenuClosed() => SetState(_selectingExistingItem);

        void OnExitBuilder() => Off();
    }
}