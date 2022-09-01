using Strawhenge.Builder.Menu;
using System;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity
{
    public class MenuView : IMenuView
    {
        MenuScript _script;

        public event Action<string> SelectCategory;
        public event Action<string> SelectItem;
        public event Action SelectBack;

        public void Setup(MenuScript script) => _script = script;

        public void Show(IReadOnlyList<string> categories, IReadOnlyList<string> items, bool enableBack)
        {
            if (_script != null)
                _script.Show(categories, items, enableBack);
        }

        public void Hide()
        {
            if (_script != null)
                _script.Hide();
        }
    }
}
