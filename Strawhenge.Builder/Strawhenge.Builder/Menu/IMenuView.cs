using System;
using System.Collections.Generic;

namespace Strawhenge.Builder.Menu
{
    public interface IMenuView
    {
        event Action Back;
        event Action<IMenuCategory> SelectCategory;
        event Action<IMenuItem> SelectItem;

        void Populate(IReadOnlyList<IMenuCategory> categories, IReadOnlyList<IMenuItem> items, bool enableBackButton);

        void Show();

        void Hide();
    }
}
