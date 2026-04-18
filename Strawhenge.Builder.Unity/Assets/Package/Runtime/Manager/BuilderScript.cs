using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.Manager.UI;
using Strawhenge.Builder.Unity.Package.Runtime.Blueprints;
using Strawhenge.Builder.Unity.Package.Runtime.UI;
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
        [SerializeField] UIContainerScript _ui;

        [SerializeField] BaseBuildItemSelectorScript _buildItemScriptSelector;
        [SerializeField] CameraControllerScript _cameraController;
        [SerializeField] DefaultPositionAccessorScript _defaultPosition;


        [SerializeField] Camera _camera;

        [SerializeField] SerializedSource<
            IControlsSettings,
            SerializedControlsSettings,
            ControlsSettingsScriptableObject> _controlsSettings;

        [SerializeField] SerializedSource<
            ILayers,
            SerializedLayers,
            LayersScriptableObject> _layers;

        [SerializeField] LoggerScript _logger;

        [SerializeField] UnityEvent _turningOn;
        [SerializeField] UnityEvent _turnedOff;

        BuilderManager _builderManager;

        public BuilderManager BuilderManager => _builderManager ??= Create();

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

            if (!_layers.TryGetValue(out var layers))
            {
                logger.LogWarning($"'{nameof(_layers)}' not set.");
                layers = NullLayers.Instance;
            }

            var controlsSettings = _controlsSettings
                .GetValueOrDefault(() => DefaultControlsSettings.Instance);

            return new BuilderManager(
                _inventory.Inventory,
                _buildItemScriptSelector.BuildItemSelector,
                _camera,
                _cameraController.CameraController,
                _defaultPosition.DefaultPositionAccessor,
                _ui.Container,
                _blueprintsRepository,
                controlsSettings,
                layers,
                logger);
        }
    }
}