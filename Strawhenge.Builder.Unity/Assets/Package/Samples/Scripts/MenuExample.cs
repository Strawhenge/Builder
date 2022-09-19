using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity;
using Strawhenge.Builder.Unity.ScriptableObjects;
using System;
using UnityEngine;

public class MenuExample : MonoBehaviour
{
    [SerializeField] BlueprintScriptableObject[] _blueprints;

    MenuView _menuView;
    BuilderMenu _menu;
    MenuItemsFactory<BlueprintScriptableObject> _menuItemsFactory;
    MainCategory _mainCategory;

    void Awake()
    {
        _menuItemsFactory = new MenuItemsFactory<BlueprintScriptableObject>();
        _menuView = new MenuView(new UnityLogger(gameObject));
        _menu = new BuilderMenu(_menuView);
    }

    void Start()
    {
        _menuView.Setup(
            FindObjectOfType<MenuScript>(includeInactive: true));

        _mainCategory = _menuItemsFactory.CreateMainCategory(_blueprints, x => print(x));
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

