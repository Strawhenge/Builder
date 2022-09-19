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
            var menuItems = items
                .Select(x => new MenuItem(x.Name, () => { }))
                .ToList();

            return new MenuCategory(
                string.Empty,
                Array.Empty<MenuCategory>(),
                menuItems);
        }
    }

    public interface ICategorizable
    {
        string Name { get; }
    }
}
