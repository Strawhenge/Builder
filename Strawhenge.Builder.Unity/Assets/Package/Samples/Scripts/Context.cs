using Strawhenge.Builder;
using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity;
using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.Factories;
using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Builder.Unity.UI;
using UnityEngine;

public class Context : MonoBehaviour
{
    [SerializeField] BlueprintScriptableObject[] _blueprints;

    MenuView _menuView;
    BuilderMenu _menu;
    MenuItemsFactory<BlueprintScriptableObject> _menuItemsFactory;
    MainCategory _mainCategory;
    BlueprintFactory _blueprintFactory;

    public BlueprintManager BlueprintManager { get; private set; }

    void Awake()
    {
        _menuItemsFactory = new MenuItemsFactory<BlueprintScriptableObject>();
        _menuView = new MenuView(new UnityLogger(gameObject));
        _menu = new BuilderMenu(_menuView);

        var logger = new UnityLogger(gameObject);
        var inventory = new ComponentInventory(logger);
        var buildItemController = new BuildItemController();
        var recipeFactory = new RecipeFactory();

        _blueprintFactory = new BlueprintFactory(recipeFactory, logger);

        BlueprintManager = new BlueprintManager(inventory, buildItemController, new NullRecipeUI())
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
            BlueprintManager.Set(
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
        {
            BlueprintManager.Unset();
            _menu.Show(_mainCategory);
        }
    }
}
