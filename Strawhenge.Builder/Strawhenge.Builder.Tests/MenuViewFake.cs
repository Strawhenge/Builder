using Strawhenge.Builder.Menu;
using System;
using System.Collections.Generic;

namespace Strawhenge.Builder.Tests
{
    internal class MenuViewFake : IMenuView
    {
        public event Action Back;
        public event Action<IMenuCategory> SelectCategory;
        public event Action<IMenuItem> SelectItem;

        internal bool IsShowing { get; private set; }

        internal IReadOnlyList<IMenuCategory> DisplayedCategories { get; private set; }

        internal IReadOnlyList<IMenuItem> DisplayedItems { get; private set; }

        internal bool IsBackButtonEnabled { get; private set; }

        void IMenuView.Hide() => IsShowing = false;

        void IMenuView.Show() => IsShowing = true;

        void IMenuView.Populate(IReadOnlyList<IMenuCategory> categories, IReadOnlyList<IMenuItem> items, bool enableBackButton)
        {
            DisplayedCategories = categories;
            DisplayedItems = items;
            IsBackButtonEnabled = enableBackButton;
        }

        internal void InvokeBack() => Back?.Invoke();

        internal void InvokeSelectCategory(IMenuCategory category) => SelectCategory?.Invoke(category);

        internal void InvokeSelectItem(IMenuItem item) => SelectItem?.Invoke(item);
    }
}
