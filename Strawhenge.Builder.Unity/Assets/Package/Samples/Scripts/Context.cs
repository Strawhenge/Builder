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
    [SerializeField] BlueprintScriptableObject[] _blueprints;
    [SerializeField] SerializableComponentQuantity[] _inventory;

    MenuView _menuView;
    BuilderMenu _menu;
    MenuItemsFactory<BlueprintScriptableObject> _menuItemsFactory;
    MainCategory _mainCategory;

    public BlueprintManager BlueprintManager { get; private set; }

    public BlueprintFactory BlueprintFactory { get; private set; }

    public ExistingBlueprintManager ExistingBlueprintManager { get; private set; }

    public ExistingBlueprintFactory ExistingBlueprintFactory { get; private set; }

    public BuildItemController BuildItemController { get; private set; }

    public ComponentInventory Inventory { get; private set; }

    void Awake()
    {
        var logger = new UnityLogger(gameObject);

        _menuItemsFactory = new MenuItemsFactory<BlueprintScriptableObject>();
        _menuView = new MenuView(logger);
        _menu = new BuilderMenu(_menuView);

        Inventory = new ComponentInventory(logger);

        BuildItemController = new BuildItemController(
            FindObjectOfType<BuildItemControls>(includeInactive: true),
            FindObjectOfType<VerticalSnapControls>(includeInactive: true),
            FindObjectOfType<HorizontalSnapControls>(includeInactive: true));

        BlueprintFactory = new BlueprintFactory(BuildItemController.LastPlacedPosition, logger);

        var buildItemCompositionUI = new BuildItemCompositionUI(logger);

        BlueprintManager = new BlueprintManager(Inventory, BuildItemController, buildItemCompositionUI);

        ExistingBlueprintFactory = new ExistingBlueprintFactory();
        ExistingBlueprintManager = new ExistingBlueprintManager(Inventory, BuildItemController, buildItemCompositionUI);
    }

    void Start()
    {
        _menuView.Setup(
            FindObjectOfType<MenuScript>(includeInactive: true));

        _mainCategory = _menuItemsFactory.CreateMainCategory(_blueprints, selectedBlueprint =>
        {
            BlueprintManager.Set(
                BlueprintFactory.Create(selectedBlueprint));
        });

        foreach (var components in _inventory)
            Inventory.AddComponent(new Component(components.Component.Identifier), components.Quantity);
    }

    void Update()
    {
        HandleMenuToggle();
        HandleExistingItemClick();
        HandleScrapTrigger();
    }

    void HandleMenuToggle()
    {
        if (!Input.GetKeyUp(KeyCode.Escape))
            return;

        if (_menu.IsShowing)
            _menu.Hide();
        else
        {
            BlueprintManager.Unset();
            _menu.Show(_mainCategory);
        }
    }

    void HandleExistingItemClick()
    {
        if (Input.GetMouseButtonDown(0) &&
            Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var hit))
        {
            var buildItemScript = hit.transform.root.GetComponentInChildren<BuildItemScript>();

            if (buildItemScript != null)
            {
                ExistingBlueprintManager.Set(
                    ExistingBlueprintFactory.Create(buildItemScript));
            }
        }
    }

    void HandleScrapTrigger()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
            ExistingBlueprintManager.Scrap();
    }
}