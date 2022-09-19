using System;
using System.Collections.Generic;
using System.Linq;

namespace Strawhenge.Builder.Menu
{
    class MainCategoryBuilder
    {
        readonly List<MenuItem> _uncategorizedMenuItems = new List<MenuItem>();
        readonly List<string> _topLevelCategories = new List<string>();
        readonly Dictionary<string, List<MenuItem>> _menuItemsByCategory = new Dictionary<string, List<MenuItem>>();
        readonly Dictionary<string, List<string>> _categoriesByParent = new Dictionary<string, List<string>>();

        public MainCategory Build()
        {
            List<MenuCategory> categories = new List<MenuCategory>();

            foreach (var parentCategory in _topLevelCategories)
            {
                categories.Add(CreateCategory(parentCategory));
            }

            return new MainCategory(categories, _uncategorizedMenuItems);
        }

        public void AddUncategorized(MenuItem menuItem)
        {
            _uncategorizedMenuItems.Add(menuItem);
        }

        public void AddCategorized(Category category, MenuItem menuItem)
        {
            if (!_menuItemsByCategory.ContainsKey(category.Name))
                _menuItemsByCategory.Add(category.Name, new List<MenuItem>());

            _menuItemsByCategory[category.Name].Add(menuItem);

            AddCategory(category);
        }

        MenuCategory CreateCategory(string categoryName)
        {
            var subCategories = _categoriesByParent.ContainsKey(categoryName)
                ? _categoriesByParent[categoryName].Select(x => CreateCategory(x)).ToArray()
                : Array.Empty<MenuCategory>();

            var items = _menuItemsByCategory.ContainsKey(categoryName)
                ? _menuItemsByCategory[categoryName].ToArray()
                : Array.Empty<MenuItem>();

            return new MenuCategory(categoryName, subCategories, items);
        }

        void AddCategory(Category category)
        {
            if (!category.Parent.HasSome(out var parent))
            {
                if (!_topLevelCategories.Contains(category.Name))
                    _topLevelCategories.Add(category.Name);
                return;
            }

            if (!_categoriesByParent.ContainsKey(parent.Name))
                _categoriesByParent.Add(parent.Name, new List<string>());

            if (!_categoriesByParent[parent.Name].Contains(category.Name))
                _categoriesByParent[parent.Name].Add(category.Name);

            AddCategory(parent);
        }
    }
}
