using System;
using System.Collections.Generic;
using System.Text;

namespace Strawhenge.Builder.Menu
{
    public class MenuCategoryFactory<T>
    {
        public MenuCategory Create(IEnumerable<T> items)
        {
            return new MenuCategory(string.Empty, Array.Empty<MenuCategory>(), Array.Empty<MenuItem>());
        }
    }
}
