using Strawhenge.Builder;
using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity;
using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.Data;
using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Builder.Unity.UI;
using Strawhenge.Common.Unity;
using UnityEngine;
using BuilderManagerUI = Strawhenge.Builder.Unity.Manager.UI.BuilderManagerUI;
using Component = Strawhenge.Builder.Component;

public class Context : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] SerializableComponentQuantity[] _inventory;
    [SerializeField] BuilderScript _builderScript;
    [SerializeField] BuildItemScriptSelector _buildItemScriptSelector;

    BuilderManager _builderManager;
    ComponentInventory _componentInventory;

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

        var blueprintFactory = new BlueprintFactory(buildItemController.LastPlacedPosition, logger);

        var buildItemCompositionUI = new BuildItemCompositionUI(logger);

        var blueprintManager = new BlueprintManager(_componentInventory, buildItemController, buildItemCompositionUI);
        var existingBlueprintManager =
            new ExistingBlueprintManager(_componentInventory, buildItemController, buildItemCompositionUI);

        var markersToggle = new MarkersToggle(_camera, Layers.Instance);

        var blueprintRepository = new BlueprintRepository();
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

        _builderScript.BlueprintRepository = blueprintRepository;
        _builderScript.ManagerUI = managerUI;
        _builderScript.ItemCompositionUI = buildItemCompositionUI;
        _builderScript.MenuView = menuView;
    }

    void Start()
    {
        foreach (var components in _inventory)
            _componentInventory.AddComponent(new Component(components.Component.Identifier), components.Quantity);
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
}