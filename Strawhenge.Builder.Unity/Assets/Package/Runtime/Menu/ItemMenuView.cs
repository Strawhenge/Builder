using System.Collections.Generic;

namespace Strawhenge.Builder.Unity
{
    public class ItemMenuView
    {
        ItemMenuScript _script;

        public void Setup(ItemMenuScript script) => _script = script;

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
