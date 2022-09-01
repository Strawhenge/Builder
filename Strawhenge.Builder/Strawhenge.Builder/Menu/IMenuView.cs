using System;
using System.Collections.Generic;

namespace Strawhenge.Builder.Menu
{
    public interface IMenuView
    {
        event Action<string> SelectCategory;

        void Show(IReadOnlyList<string> categories, IReadOnlyList<string> items, bool enableBack);

        void Hide();
    }
}
