using System.Collections.Generic;

namespace Strawhenge.Builder.Unity
{
    public class ItemMenuView
    {
        ItemMenuScript _script;

        public void Set(ItemMenuScript script) => _script = script;

        public void Show(IReadOnlyList<string> categories, IReadOnlyList<string> items)
        {
            if (_script != null)
                _script.Show(categories, items);
        }

        public void Hide()
        {
            if (_script != null)
                _script.Hide();
        }
    }
}
