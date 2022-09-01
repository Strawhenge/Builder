using Strawhenge.Builder.Menu;
using System.Collections.Generic;

namespace Strawhenge.Builder.Tests.Menu
{
    class MenuViewFake : IMenuView
    {
        public bool IsShowing { get; private set; }

        public IReadOnlyList<string> CurrentCategories { get; private set; }

        public IReadOnlyList<string> CurrentItems { get; private set; }

        public bool IsBackEnabled { get; private set; }

        void IMenuView.Hide() => IsShowing = false;

        void IMenuView.Show(IReadOnlyList<string> categories, IReadOnlyList<string> items, bool enableBack)
        {
            IsShowing = true;
            CurrentCategories = categories;
            CurrentItems = items;
            IsBackEnabled = enableBack;
        }
    }
}
