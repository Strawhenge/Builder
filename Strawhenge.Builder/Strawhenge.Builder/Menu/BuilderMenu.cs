using System;
using System.Linq;
using System.Text;

namespace Strawhenge.Builder.Menu
{
    public class BuilderMenu
    {
        readonly IMenuItemsProvider _items;
        readonly IMenuView _view;

        public BuilderMenu(IMenuItemsProvider items, IMenuView view)
        {
            _items = items;
            _view = view;
        }

        public void Show()
        {
            var mainCategory = _items.GetMainCategory();

            _view.Show(
                categories: mainCategory.Subcategories.Select(x => x.Name).ToArray(),
                items: new string[0],
                enableBack: false);
        }

        public void Hide()
        {
            _view.Hide();
        }
    }
}
