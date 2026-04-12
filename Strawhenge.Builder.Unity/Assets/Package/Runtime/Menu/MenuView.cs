using Strawhenge.Builder.Menu;
using Strawhenge.Common.Logging;
using System;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity
{
    public class MenuView : IMenuView
    {
        readonly MenuScript _script;

        public MenuView(MenuScript script)
        {
            _script = script;
            _script.SelectCategory = x => SelectCategory?.Invoke(x);
            _script.SelectItem = x => SelectItem?.Invoke(x);
            _script.SelectBack = () => SelectBack?.Invoke();
            _script.SelectExit = () => SelectExit?.Invoke();
        }

        public event Action<string> SelectCategory;
        public event Action<string> SelectItem;
        public event Action SelectBack;
        public event Action SelectExit;

        public void Show(IReadOnlyList<string> categories, IReadOnlyList<string> items, bool enableBack)
        {
            _script.Show(categories, items, enableBack);
        }

        public void Hide()
        {
            _script.Hide();
        }
    }
}