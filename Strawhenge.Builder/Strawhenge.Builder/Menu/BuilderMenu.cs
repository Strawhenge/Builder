using System.Collections.Generic;
using System.Linq;

namespace Strawhenge.Builder.Menu
{
    public class BuilderMenu
    {
        readonly Stack<MenuCategory> _previousCategories = new Stack<MenuCategory>();
        readonly IMenuView _view;

        MenuCategory _currentCategory;

        public BuilderMenu(IMenuView view)
        {
            _view = view;
        }

        public bool IsShowing { get; private set; }

        public void Show(MenuCategory mainCategory)
        {
            if (IsShowing)
                Hide();

            _view.SelectCategory += OnCategorySelected;
            _view.SelectItem += OnItemSelected;
            _view.SelectBack += OnBackSelected;

            IsShowing = true;

            SetCurrentCategory(mainCategory);
        }

        public void Hide()
        {
            if (!IsShowing)
                return;

            _view.SelectCategory -= OnCategorySelected;
            _view.SelectItem -= OnItemSelected;
            _view.SelectBack -= OnBackSelected;

            IsShowing = false;

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
