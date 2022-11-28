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
using Component = Strawhenge.Builder.Component;

public class Context : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] SerializableComponentQuantity[] _inventory;
    [SerializeField] BuilderScript _builderScript;
    [SerializeField] BuildItemScriptSelector _buildItemScriptSelector;
    [SerializeField] BuilderManagerUI _builderManagerUI;

    BuilderManager _builderManager;

    public ComponentInventory Inventory { get; private set; }

    void Awake()
    {
        var logger = new UnityLogger(gameObject);

        var menuItemsFactory = new MenuItemsFactory<BlueprintScriptableObject>();
        var menuView = new MenuView(logger);
        var menu = new BuilderMenu(menuView);

        Inventory = new ComponentInventory(logger);

        var buildItemController = new BuildItemController(
            FindObjectOfType<BuildItemControls>(includeInactive: true),
            FindObjectOfType<VerticalSnapControls>(includeInactive: true),
            FindObjectOfType<HorizontalSnapControls>(includeInactive: true));

        var blueprintFactory = new BlueprintFactory(buildItemController.LastPlacedPosition, logger);

        var buildItemCompositionUI = new BuildItemCompositionUI(logger);

        var blueprintManager = new BlueprintManager(Inventory, buildItemController, buildItemCompositionUI);
        var existingBlueprintManager = new ExistingBlueprintManager(Inventory, buildItemController, buildItemCompositionUI);

        var markersToggle = new MarkersToggle(_camera, Layers.Instance);

        var blueprintRepository = new BlueprintRepository();
        var blueprintScriptableObjectMenu = new BlueprintScriptableObjectMenu(menu, menuItemsFactory, blueprintRepository);

        _builderManager = new BuilderManager(
            _buildItemScriptSelector,
            markersToggle,
            existingBlueprintManager,
            blueprintManager,
            blueprintFactory,
            _builderManagerUI,
            blueprintScriptableObjectMenu);

        _builderScript.Manager = _builderManager;
        _builderScript.BlueprintRepository = blueprintRepository;
        _builderScript.MenuView = menuView;
    }

    void Start()
    {
        foreach (var components in _inventory)
            Inventory.AddComponent(new Component(components.Component.Identifier), components.Quantity);

        _builderManager.On();
    }

    [ContextMenu("Builder On")]
    public void BuilderOn()
    {
        _builderManager.On();
    }
}