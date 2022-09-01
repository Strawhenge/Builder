using Strawhenge.Builder.Menu;
using System;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity
{
    public class MenuView : IMenuView
    {
        readonly ILogger _logger;
        MenuScript _script;

        public MenuView(ILogger logger)
        {
            _logger = logger;
        }

        public event Action<string> SelectCategory;
        public event Action<string> SelectItem;
        public event Action SelectBack;

        public void Setup(MenuScript script)
        {
            _script = script;
            _script.SelectCategory = SelectCategory;
            _script.SelectItem = SelectItem;
            _script.SelectBack = SelectBack;
        }

        public void Show(IReadOnlyList<string> categories, IReadOnlyList<string> items, bool enableBack)
        {
            if (_script == null)
            {
                _logger.LogError($"{nameof(MenuScript)} is missing.");
                return;
            }

            _script.Show(categories, items, enableBack);
        }

        public void Hide()
        {
            if (_script == null)
            {
                _logger.LogError($"{nameof(MenuScript)} is missing.");
                return;
            }

            _script.Hide();
        }
    }
}
