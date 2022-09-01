using System;
using System.Collections.Generic;

namespace Strawhenge.Builder.Menu
{
    public class MenuCategory
    {
        public MenuCategory(string name, IReadOnlyList<MenuCategory> subcategories, IReadOnlyList<MenuItem> items)
        {
            Name = name;
            Subcategories = subcategories;
            Items = items;
        }

        public string Name { get; }

        public IReadOnlyList<MenuCategory> Subcategories { get; }

        public IReadOnlyList<MenuItem> Items { get; }
    }
}
