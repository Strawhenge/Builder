using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity;
using System;
using UnityEngine;

public class MenuExample : MonoBehaviour
{
    MenuView _menuView;
    BuilderMenu _menu;
    MenuCategory _mainCategory;

    void Awake()
    {
        _menuView = new MenuView(new UnityLogger(gameObject));
        _menu = new BuilderMenu(_menuView);
    }

    void Start()
    {
        _menuView.Setup(
            FindObjectOfType<MenuScript>(includeInactive: true));

        _mainCategory = CreateMainCategory();
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

    const string Wall = "Wall";
    const string Floor = "Floor";
    const string Structure = "Structure";
    const string Workbench = "Workbench";
    const string Utility = "Utility";
    const string Chair = "Chair";
    const string Table = "Table";
    const string Furniture = "Furniture";

    MenuCategory CreateMainCategory()
    {
        var wall = CreateMenuItem(Wall);
        var floor = CreateMenuItem(Floor);

        var structure = new MenuCategory(Structure, Array.Empty<MenuCategory>(), new MenuItem[] { wall, floor });

        var workbench = CreateMenuItem(Workbench);

        var utility = new MenuCategory(Utility, Array.Empty<MenuCategory>(), new MenuItem[] { workbench });

        var chair = CreateMenuItem(Chair);
        var table = CreateMenuItem(Table);

        var furniture = new MenuCategory(Furniture, new MenuCategory[] { utility }, new MenuItem[] { chair, table });

        return new MenuCategory(string.Empty, new MenuCategory[] { structure, furniture }, Array.Empty<MenuItem>());
    }

    MenuItem CreateMenuItem(string name) =>
            new MenuItem(name, () => Debug.Log(name));
}

