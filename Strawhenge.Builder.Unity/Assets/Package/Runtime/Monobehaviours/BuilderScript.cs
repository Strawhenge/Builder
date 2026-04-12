using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity.Manager.UI;
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

        public BuilderManager BuilderManager { private get; set; }

        public BuilderManagerUI ManagerUI { private get; set; }

        public BuildItemCompositionUI ItemCompositionUI { private get; set; }

        public MenuView MenuView { private get; set; }

        [ContextMenu(nameof(On))]
        public void On() => BuilderManager.On();

        [ContextMenu(nameof(Off))]
        public void Off() => BuilderManager.Off();

        void Start()
        {
            if (!ReferenceEquals(null, _managerUI))
                ManagerUI.Setup(_managerUI);

            if (!ReferenceEquals(null, _itemCompositionUI))
                ItemCompositionUI.Setup(_itemCompositionUI);

            BuilderManager.TurningOn += OnBuilderTuringOn;
            BuilderManager.TurnedOff += OnBuilderTurningOff;
        }

        void OnDestroy()
        {
            ManagerUI.Reset();
            ItemCompositionUI.Reset();

            BuilderManager.TurningOn -= OnBuilderTuringOn;
            BuilderManager.TurnedOff -= OnBuilderTurningOff;
        }

        void OnBuilderTuringOn() => _turningOn.Invoke();

        void OnBuilderTurningOff() => _turnedOff.Invoke();

        BuilderManager Create()
        {
            ComponentRefHelper.EnsureCamera(ref _camera, nameof(_camera), this);

            var logger = _logger != null
                ? _logger.Logger
                : new UnityLogger(gameObject);

            IBuildItemScriptSelector buildItemSelector = null;

            var layers = _layers.GetValue(); // TODO Handle missing case.

            var markers = new MarkersToggle(_camera, layers);

            var existingBlueprintManager = new ExistingBlueprintManager(
                _inventory.Inventory,
                buildItemController: null,
                scrapUI: null);

            var blueprintManager = new BlueprintManager(
                _inventory.Inventory,
                buildItemController: null,
                recipeUI: null);

            var blueprintFactory = new BlueprintFactory(
                builderProgressTracker: null,
                initialPositionAccessor: null,
                logger);

            var builderManagerUI = new BuilderManagerUI(logger);

            var builderMenuView = new MenuView(_menu);
            var builderMenu = new BuilderMenu(builderMenuView);
            var menu = new BlueprintScriptableObjectMenu(
                builderMenu,
                menuItemsFactory: null,
                blueprints: null);

            return new BuilderManager(
                buildItemSelector,
                markers,
                existingBlueprintManager,
                blueprintManager,
                blueprintFactory,
                builderManagerUI,
                menu);
        }
    }
}