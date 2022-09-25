using Strawhenge.Builder;
using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity;
using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.Data;
using Strawhenge.Builder.Unity.Factories;
using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Builder.Unity.UI;
using UnityEngine;
using Component = Strawhenge.Builder.Component;

public class Context : MonoBehaviour
{
    [SerializeField] BlueprintScriptableObject[] _blueprints;
    [SerializeField] SerializableComponentQuantity[] _inventory;

    MenuView _menuView;
    BuilderMenu _menu;
    MenuItemsFactory<BlueprintScriptableObject> _menuItemsFactory;
    MainCategory _mainCategory;

    public BlueprintManager BlueprintManager { get; private set; }

    public BlueprintFactory BlueprintFactory { get; private set; }

    public BuildItemController BuildItemController { get; private set; }

    public ComponentInventory Inventory { get; private set; }

    void Awake()
    {
        _menuItemsFactory = new MenuItemsFactory<BlueprintScriptableObject>();
        _menuView = new MenuView(new UnityLogger(gameObject));
        _menu = new BuilderMenu(_menuView);

        var logger = new UnityLogger(gameObject);
        var recipeFactory = new RecipeFactory();

        Inventory = new ComponentInventory(logger);
        BuildItemController = new BuildItemController();
        BlueprintFactory = new BlueprintFactory(recipeFactory, BuildItemController.LastPlacedPosition, logger);

        BlueprintManager = new BlueprintManager(Inventory, BuildItemController, new RecipeUI(logger));
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
}
