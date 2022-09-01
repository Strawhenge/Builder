using System;

namespace Strawhenge.Builder.Menu
{
    public class MenuItem
    {
        readonly Action _onSelect;

        public MenuItem(string name, Action onSelect)
        {
            _onSelect = onSelect;

            Name = name;
        }

        public string Name { get; }

        public void Select() => _onSelect();
    }
}
