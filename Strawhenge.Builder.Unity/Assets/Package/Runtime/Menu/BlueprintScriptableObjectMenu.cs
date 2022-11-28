using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity.ScriptableObjects;
using System;

namespace Strawhenge.Builder.Unity
{
    public class BlueprintScriptableObjectMenu : IBlueprintScriptableObjectMenu
    {
        readonly BuilderMenu _menu;
        readonly Lazy<MainCategory> _mainCategory;

        public BlueprintScriptableObjectMenu(
            BuilderMenu menu,
            MenuItemsFactory<BlueprintScriptableObject> menuItemsFactory,
            IBlueprintRepository blueprints)
        {
            _menu = menu;
            _menu.Exited += () => Exit?.Invoke();

            _mainCategory = new Lazy<MainCategory>(() =>
                menuItemsFactory.CreateMainCategory(blueprints.GetAll(), blueprint => Select?.Invoke(blueprint)));
        }

        public event Action<BlueprintScriptableObject> Select;
        public event Action Exit;

        public void Open() => _menu.Show(_mainCategory.Value);

        public void Close() => _menu.Hide();
    }
}