using Strawhenge.Builder.Menu;
using System;
using System.Collections.Generic;

namespace Strawhenge.Builder.Tests.Menu
{
    class MenuViewFake : IMenuView
    {
        public event Action<string> SelectCategory;
        public event Action<string> SelectItem;
        public event Action SelectBack;
        public event Action SelectExit;

        public bool IsShowing { get; private set; }

        public IReadOnlyList<string> CurrentCategories { get; private set; }

        public IReadOnlyList<string> CurrentItems { get; private set; }

        public bool IsBackEnabled { get; private set; }

        public void InvokeSelectCategory(string category) => SelectCategory?.Invoke(category);

        public void InvokeSelectItem(string item) => SelectItem?.Invoke(item);

        public void InvokeSelectBack() => SelectBack?.Invoke();

        public void InvokeSelectExit() => SelectExit?.Invoke();

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
