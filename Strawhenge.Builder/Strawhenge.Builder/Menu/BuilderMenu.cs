using System;
using System.Linq;
using System.Text;

namespace Strawhenge.Builder.Menu
{
    public class BuilderMenu
    {
        readonly IMenuItemsProvider _items;
        readonly IMenuView _view;

        MenuCategory _currentCategory;

        public BuilderMenu(IMenuItemsProvider items, IMenuView view)
        {
            _items = items;
            _view = view;

            _view.SelectCategory += OnCategorySelected;
        }

        public void Show()
        {
            SetCurrentCategory(_items.GetMainCategory(), enableBack: false);
        }

        public void Hide()
        {
            _view.Hide();
        }

        void SetCurrentCategory(MenuCategory category, bool enableBack = true)
        {
            _currentCategory = category;

            _view.Show(
                categories: _currentCategory.Subcategories.Select(x => x.Name).ToArray(),
                items: _currentCategory.Items.Select(x => x.Name).ToArray(),
                enableBack);
        }

        void OnCategorySelected(string categoryName)
        {
            var category = _currentCategory.Subcategories.FirstOrDefault(x => x.Name == categoryName);

            if (category != null)
                SetCurrentCategory(category);
        }
    }
}
