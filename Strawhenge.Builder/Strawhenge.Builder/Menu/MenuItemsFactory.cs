using System;
using System.Collections.Generic;

namespace Strawhenge.Builder.Menu
{
    public class MenuItemsFactory<T> where T : ICategorizable
    {
        public MainCategory CreateMainCategory(IEnumerable<T> items, Action<T> onSelect)
        {
            var builder = new MainCategoryBuilder();

            foreach (var item in items)
            {
                var menuItem = new MenuItem(item.Name, () => onSelect(item));

                if (item.Category.HasSome(out var category))
                {
                    builder.AddCategorized(category, menuItem);
                }
                else
                {
                    builder.AddUncategorized(menuItem);
                }
            }

            return builder.Build();
        }
    }
}
