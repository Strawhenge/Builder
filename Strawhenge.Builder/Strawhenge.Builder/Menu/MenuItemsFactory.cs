using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strawhenge.Builder.Menu
{
    public class MenuItemsFactory<T> where T : ICategorizable
    {
        public MainCategory CreateMainCategory(IEnumerable<T> items, Action<T> onSelect)
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            Dictionary<string, List<MenuItem>> menuItemsByCategory = new Dictionary<string, List<MenuItem>>();
            Dictionary<string, List<string>> subCategories = new Dictionary<string, List<string>>();
            List<string> parentCategories = new List<string>();

            foreach (var item in items)
            {
                if (item.Category.HasSome(out var category))
                {
                    if (!menuItemsByCategory.ContainsKey(category.Name))
                        menuItemsByCategory.Add(category.Name, new List<MenuItem>());

                    menuItemsByCategory[category.Name].Add(new MenuItem(item.Name, () => onSelect(item)));

                    AddCategory(category, parentCategories, subCategories);
                }
                else
                {
                    menuItems.Add(new MenuItem(item.Name, () => onSelect(item)));
                }
            }

            List<MenuCategory> categories = new List<MenuCategory>();

            foreach (var parentCategory in parentCategories)
            {
                categories.Add(CreateCategory(parentCategory, menuItemsByCategory, subCategories));
            }

            return new MainCategory(categories, menuItems);
        }

        MenuCategory CreateCategory(string categoryName, Dictionary<string, List<MenuItem>> menuItemsByCategory, Dictionary<string, List<string>> subCategoriesByCategory)
        {
            var subCategories = subCategoriesByCategory.ContainsKey(categoryName)
                ? subCategoriesByCategory[categoryName].Select(x => CreateCategory(x, menuItemsByCategory, subCategoriesByCategory)).ToArray()
                : Array.Empty<MenuCategory>();

            return new MenuCategory(categoryName, subCategories, menuItemsByCategory.ContainsKey(categoryName) ? menuItemsByCategory[categoryName].ToArray() : Array.Empty<MenuItem>());
        }

        void AddCategory(Category category, List<string> parentCategories, Dictionary<string, List<string>> subCategories)
        {
            if (!category.Parent.HasSome(out var parent))
            {
                if (!parentCategories.Contains(category.Name))
                    parentCategories.Add(category.Name);
                return;
            }

            if (!subCategories.ContainsKey(parent.Name))
                subCategories.Add(parent.Name, new List<string>());

            if (!subCategories[parent.Name].Contains(category.Name))
                subCategories[parent.Name].Add(category.Name);

            AddCategory(parent, parentCategories, subCategories);
        }
    }
}
