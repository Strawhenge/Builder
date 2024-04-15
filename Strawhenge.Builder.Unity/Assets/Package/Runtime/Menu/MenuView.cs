using Strawhenge.Builder.Menu;
using Strawhenge.Common.Logging;
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
        public event Action SelectExit;

        public void Setup(MenuScript script)
        {
            _script = script;
            _script.SelectCategory = x => SelectCategory?.Invoke(x);
            _script.SelectItem = x => SelectItem?.Invoke(x);
            _script.SelectBack = () => SelectBack?.Invoke();
            _script.SelectExit = () => SelectExit?.Invoke();
        }

        public void Reset()
        {
            _script.SelectCategory = null;
            _script.SelectItem = null;
            _script.SelectBack = null;
            _script.SelectExit = null;
            _script = null;
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