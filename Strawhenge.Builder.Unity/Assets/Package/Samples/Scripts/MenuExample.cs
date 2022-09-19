using Strawhenge.Builder;
using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity;
using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.Factories;
using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Builder.Unity.UI;
using UnityEngine;

public class MenuExample : MonoBehaviour
{
    [SerializeField] BlueprintScriptableObject[] _blueprints;

    MenuView _menuView;
    BuilderMenu _menu;
    MenuItemsFactory<BlueprintScriptableObject> _menuItemsFactory;
    MainCategory _mainCategory;

    BlueprintManager _blueprintManager;
    BlueprintFactory _blueprintFactory;

    void Awake()
    {
        _menuItemsFactory = new MenuItemsFactory<BlueprintScriptableObject>();
        _menuView = new MenuView(new UnityLogger(gameObject));
        _menu = new BuilderMenu(_menuView);

        var logger = new UnityLogger(gameObject);
        var inventory = new ComponentInventory(logger);
        var buildItemController = new BuildItemController();
        var recipeFactory = new RecipeFactory();
        var spawner = new Spawner();

        _blueprintFactory = new BlueprintFactory(recipeFactory, spawner, logger);
        _blueprintManager = new BlueprintManager(inventory, buildItemController, new NullRecipeUI())
        {
            DefaultPosition = transform.position
        };
    }

    void Start()
    {
        _menuView.Setup(
            FindObjectOfType<MenuScript>(includeInactive: true));

        _mainCategory = _menuItemsFactory.CreateMainCategory(_blueprints, selectedBlueprint =>
        {
            _blueprintManager.Set(
                _blueprintFactory.Create(selectedBlueprint));
        });
    }

    void Update()
    {
        if (!Input.GetKeyUp(KeyCode.Escape))
            return;

        if (_menu.IsShowing)
            _menu.Hide();
        else
            _menu.Show(_mainCategory);
    }
}

