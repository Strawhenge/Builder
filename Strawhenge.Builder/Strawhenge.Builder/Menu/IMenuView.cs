using System;
using System.Collections.Generic;

namespace Strawhenge.Builder.Menu
{
    public interface IMenuView
    {
        event Action<string> SelectCategory;
        event Action<string> SelectItem;
        event Action SelectBack;

        void Show(IReadOnlyList<string> categories, IReadOnlyList<string> items, bool enableBack);

        void Hide();
    }
}
