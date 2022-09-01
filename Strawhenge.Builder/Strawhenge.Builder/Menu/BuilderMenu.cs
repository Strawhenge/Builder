using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strawhenge.Builder.Menu
{
    public class BuilderMenu
    {
        readonly Stack<MenuCategory> _previousCategories = new Stack<MenuCategory>();
        readonly IMenuItemsProvider _items;
        readonly IMenuView _view;

        MenuCategory _currentCategory;

        public BuilderMenu(IMenuItemsProvider items, IMenuView view)
        {
            _items = items;
            _view = view;

            _view.SelectCategory += OnCategorySelected;
            _view.SelectItem += OnItemSelected;
            _view.SelectBack += OnBackSelected;
        }

        public void Show()
        {
            SetCurrentCategory(_items.GetMainCategory());
        }

        public void Hide()
        {
            _view.Hide();
            _currentCategory = null;
            _previousCategories.Clear();
        }

        void SetCurrentCategory(MenuCategory category)
        {
            _currentCategory = category;

            _view.Show(
                categories: _currentCategory.Subcategories.Select(x => x.Name).ToArray(),
                items: _currentCategory.Items.Select(x => x.Name).ToArray(),
                enableBack: _previousCategories.Any());
        }

        void OnCategorySelected(string categoryName)
        {
            if (_currentCategory != null)
                _previousCategories.Push(_currentCategory);

            var category = _currentCategory.Subcategories.FirstOrDefault(x => x.Name == categoryName);

            if (category != null)
                SetCurrentCategory(category);
        }

        void OnItemSelected(string itemName)
        {
            var item = _currentCategory.Items.FirstOrDefault(x => x.Name == itemName);

            if (item == null)
                return;

            Hide();
            item.Select();
        }

        void OnBackSelected()
        {
            if (_previousCategories.Any())
                SetCurrentCategory(_previousCategories.Pop());
        }
    }
}
