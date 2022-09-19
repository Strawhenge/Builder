using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strawhenge.Builder.Menu
{
    public class MenuCategoryFactory<T> where T : ICategorizable
    {
        public MenuCategory Create(IEnumerable<T> items)
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            Dictionary<string, List<MenuItem>> menuItemsByCategory = new Dictionary<string, List<MenuItem>>();
         
            foreach (var item in items)
            {
                if (item.Category.HasSome(out var category))
                {
                    if (!menuItemsByCategory.ContainsKey(category.Name))
                        menuItemsByCategory.Add(category.Name, new List<MenuItem>());

                    menuItemsByCategory[category.Name].Add(new MenuItem(item.Name, () => { }));
                }
                else
                {
                    menuItems.Add(new MenuItem(item.Name, () => { }));
                }
            }

            var categories = menuItemsByCategory
                .Select(x => new MenuCategory(x.Key, Array.Empty<MenuCategory>(), x.Value))
                .ToList();

            return new MenuCategory(
                string.Empty,
                categories,
                menuItems);
        }
    }
}
