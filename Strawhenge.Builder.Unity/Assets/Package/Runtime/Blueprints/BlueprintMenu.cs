using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity.Blueprints.Repository;
using System;

namespace Strawhenge.Builder.Unity.Blueprints
{
    class BlueprintMenu
    {
        readonly BuilderMenu _menu;
        readonly Lazy<MainCategory> _mainCategory;

        public BlueprintMenu(
            BuilderMenu menu,
            IBlueprintRepository blueprints)
        {
            _menu = menu;
            _menu.Exited += () => Exit?.Invoke();

            var menuItemsFactory = new MenuItemsFactory<IBlueprint>();
            _mainCategory = new Lazy<MainCategory>(() => menuItemsFactory.CreateMainCategory(blueprints.GetAll(),
                blueprint => Select?.Invoke(blueprint)));
        }

        public event Action<IBlueprint> Select;
        public event Action Exit;

        public void Open() => _menu.Show(_mainCategory.Value);

        public void Close() => _menu.Hide();
    }
}