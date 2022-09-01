using System.Collections.Generic;

namespace Strawhenge.Builder.Menu
{
    public interface IMenuView
    {
        void Show(IReadOnlyList<string> categories, IReadOnlyList<string> items, bool enableBack);

        void Hide();
    }
}
