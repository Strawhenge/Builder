using Strawhenge.Builder;
using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity;
using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.Data;
using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Builder.Unity.Progress;
using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Builder.Unity.UI;
using Strawhenge.Common.Unity;
using Strawhenge.Common.Unity.Camera;
using UnityEngine;
using BuilderManagerUI = Strawhenge.Builder.Unity.Manager.UI.BuilderManagerUI;
using Component = Strawhenge.Builder.Component;

public class Context : MonoBehaviour
{
    [SerializeField] SerializableComponentQuantity[] _inventory;
    [SerializeField] BuilderScript _builderScript;
    [SerializeField] BuildItemScriptSelector _buildItemScriptSelector;

    BuilderManager _builderManager;
    ComponentInventory _componentInventory;
    BuilderProgressLoader _builderProgressLoader;
    BuilderProgressTracker _progressTracker;

    void Awake()
    {
        var logger = new UnityLogger(gameObject);

        var menuItemsFactory = new MenuItemsFactory<BlueprintScriptableObject>();
        var menuView = new MenuView(logger);
        var menu = new BuilderMenu(menuView);

        _componentInventory = new ComponentInventory(logger);

        var buildItemController = new BuildItemController(
            FindObjectOfType<CameraControllerScript>(includeInactive: true),
            FindObjectOfType<BuildItemControls>(includeInactive: true),
            FindObjectOfType<VerticalSnapControls>(includeInactive: true),
            FindObjectOfType<HorizontalSnapControls>(includeInactive: true));

        _progressTracker = new BuilderProgressTracker(logger);

        var blueprintFactory = new BlueprintFactory(
            _progressTracker,
            buildItemController.LastPlacedPosition,
            logger);

        var buildItemCompositionUI = new BuildItemCompositionUI(logger);

        var blueprintManager = new BlueprintManager(_componentInventory, buildItemController, buildItemCompositionUI);
        var existingBlueprintManager =
            new ExistingBlueprintManager(_componentInventory, buildItemController, buildItemCompositionUI);

        var markersToggle = new MarkersToggle(new CameraCache(), Layers.Instance);

        var blueprintRepository = new BlueprintRepository(new Settings());
        var blueprintScriptableObjectMenu =
            new BlueprintScriptableObjectMenu(menu, menuItemsFactory, blueprintRepository);

        var managerUI = new BuilderManagerUI(logger);

        _builderManager = new BuilderManager(
            _buildItemScriptSelector,
            markersToggle,
            existingBlueprintManager,
            blueprintManager,
            blueprintFactory,
            managerUI,
            blueprintScriptableObjectMenu);

        _builderScript.ManagerUI = managerUI;
        _builderScript.ItemCompositionUI = buildItemCompositionUI;
        _builderScript.MenuView = menuView;
        _builderScript.BuilderManager = _builderManager;

        _builderProgressLoader = new BuilderProgressLoader(
            blueprintRepository,
            blueprintFactory,
            logger);
    }

    void Start()
    {
        foreach (var components in _inventory)
            _componentInventory.AddComponent(new Component(components.Component.Identifier), components.Quantity);

        foreach (var buildItem in Object.FindObjectsOfType<BuildItemScript>())
            _progressTracker.Add(buildItem, buildItem.gameObject.name);
    }

    [ContextMenu("Builder On")]
    public void BuilderOn()
    {
        _builderManager.On();
    }

    [ContextMenu("Builder Off")]
    public void BuilderOff()
    {
        _builderManager.Off();
    }

    [ContextMenu("Load Progress")]
    public void LoadBuilderProgress()
    {
        _builderProgressLoader.Load(
            BuilderProgressSample.Data);
    }

    [ContextMenu("Print Progress")]
    public void PrintProgress()
    {
        var progress = _progressTracker.GetCurrentProgress();

        foreach (var buildItem in progress.BuildItems)
            print($"{buildItem.Name} [p: {buildItem.Position}] [r: {buildItem.Rotation}]");
    }
}