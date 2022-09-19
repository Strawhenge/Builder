using System.Collections.Generic;

namespace Strawhenge.Builder.Menu
{
    public class MainCategory : MenuCategory
    {
        public MainCategory(IReadOnlyList<MenuCategory> categories, IReadOnlyList<MenuItem> items)
            : base(string.Empty, categories, items)
        {
        }
    }
}
