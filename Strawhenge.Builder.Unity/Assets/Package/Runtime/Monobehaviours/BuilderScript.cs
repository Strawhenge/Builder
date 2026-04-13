using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.Manager.UI;
using Strawhenge.Builder.Unity.Package.Runtime.Blueprints;
using Strawhenge.Builder.Unity.Progress;
using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Builder.Unity.UI;
using Strawhenge.Common.Unity;
using Strawhenge.Common.Unity.Helpers;
using Strawhenge.Common.Unity.Serialization;
using UnityEngine;
using UnityEngine.Events;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class BuilderScript : MonoBehaviour
    {
        [SerializeField] ComponentInventoryScript _inventory;
        [SerializeField] BlueprintsRepositoryScript _blueprintsRepository;
        [SerializeField] ControlsScript _controls;
        [SerializeField] BaseBuildItemScriptSelectorScript _buildItemScriptSelector;
        [SerializeField] CameraControllerScript _cameraController;
        [SerializeField] DefaultPositionAccessorScript _defaultPosition;
        [SerializeField] BuilderManagerUIScript _managerUI;
        [SerializeField] BuildItemCompositionUIScript _itemCompositionUI;
        [SerializeField] MenuScript _menu;

        [SerializeField] Camera _camera;

        [SerializeField] SerializedSource<
            ILayers,
            SerializedLayers,
            LayersScriptableObject> _layers;

        [SerializeField] LoggerScript _logger;

        [SerializeField] UnityEvent _turningOn;
        [SerializeField] UnityEvent _turnedOff;

        BuilderManager _builderManager;

        public BuilderManager BuilderManager => _builderManager ??= Create();

        [ContextMenu(nameof(On))]
        public void On() => BuilderManager.On();

        [ContextMenu(nameof(Off))]
        public void Off() => BuilderManager.Off();

        void Awake()
        {
            _builderManager ??= Create();
            _builderManager.TurningOn += OnBuilderTuringOn;
            _builderManager.TurnedOff += OnBuilderTurningOff;
        }

        void OnBuilderTuringOn() => _turningOn.Invoke();

        void OnBuilderTurningOff() => _turnedOff.Invoke();

        BuilderManager Create()
        {
            ComponentRefHelper.EnsureCamera(ref _camera, nameof(_camera), this);

            var logger = _logger != null
                ? _logger.Logger
                : new UnityLogger(gameObject);

            var layers = _layers.GetValue(); // TODO Handle missing case.

            var markers = new MarkersToggle(_camera, layers);

            var buildItemController = new BuildItemController(
                camera: _cameraController.CameraController,
                _controls.BuildItemControls,
                _controls.VerticalSnapControls,
                _controls.HorizontalSnapControls);

            var existingBlueprintManager = new ExistingBlueprintManager(
                _inventory.Inventory,
                buildItemController,
                _itemCompositionUI);

            var blueprintManager = new BlueprintManager(
                _inventory.Inventory,
                buildItemController,
                _itemCompositionUI);

            var builderProgressTracker = new BuilderProgressTracker(logger); // TODO Needs to be exposed.

            var blueprintFactory = new BlueprintFactory(
                builderProgressTracker,
                _defaultPosition.DefaultPositionAccessor,
                logger);

            var menuItemsFactory = new MenuItemsFactory<BlueprintScriptableObject>();
            var builderMenu = new BuilderMenu(_menu);
            var menu = new BlueprintScriptableObjectMenu(
                builderMenu,
                menuItemsFactory,
                _blueprintsRepository);

            return new BuilderManager(
                _buildItemScriptSelector.BuildItemScriptSelector,
                markers,
                existingBlueprintManager,
                blueprintManager,
                blueprintFactory,
                _managerUI,
                menu);
        }
    }
}