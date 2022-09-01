using Strawhenge.Builder.Menu;
using System;
using System.Collections.Generic;

namespace Strawhenge.Builder.Tests.Menu
{
    public partial class BuilderMenuTests
    {
        readonly List<string> _selectedItems = new List<string>();

        const string Wall = "Wall";
        const string Floor = "Floor";
        const string Structure = "Structure";
        const string Workbench = "Workbench";
        const string Utility = "Utility";
        const string Chair = "Chair";
        const string Table = "Table";
        const string Furniture = "Furniture";        

        MenuCategory CreateMainCategory()
        {
            var wall = CreateMenuItem(Wall);
            var floor = CreateMenuItem(Floor);

            var structure = new MenuCategory(Structure, Array.Empty<MenuCategory>(), new MenuItem[] { wall, floor });

            var workbench = CreateMenuItem(Workbench);

            var utility = new MenuCategory(Utility, Array.Empty<MenuCategory>(), new MenuItem[] { workbench });

            var chair = CreateMenuItem(Chair);
            var table = CreateMenuItem(Table);

            var furniture = new MenuCategory(Furniture, new MenuCategory[] { utility }, new MenuItem[] { chair, table });

            return new MenuCategory(string.Empty, new MenuCategory[] { structure, furniture }, Array.Empty<MenuItem>());
        }

        MenuItem CreateMenuItem(string name) =>
            new MenuItem(name, () => _selectedItems.Add(name));
    }
}
