using Strawhenge.Builder.Menu;
using System;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.Tests.Fakes
{
    class MenuViewFake : IMenuView
    {
        public event Action<string> SelectCategory;

        public event Action<string> SelectItem;

        public event Action SelectBack;

        public event Action SelectExit;

        public bool IsShowing { get; private set; }

        public IReadOnlyList<string> Categories { get; private set; } = Array.Empty<string>();

        public IReadOnlyList<string> Items { get; private set; } = Array.Empty<string>();

        public void InvokeSelectItem(string item) => SelectItem?.Invoke(item);

        public void InvokeSelectCategory(string name) => SelectCategory?.Invoke(name);

        public void InvokeSelectBack() => SelectBack?.Invoke();

        public void InvokeSelectExit() => SelectExit?.Invoke();

        void IMenuView.Show(IReadOnlyList<string> categories, IReadOnlyList<string> items, bool enableBack)
        {
            Categories = categories;
            Items = items;
            IsShowing = true;
        }

        void IMenuView.Hide()
        {
            Categories = Array.Empty<string>();
            Items = Array.Empty<string>();
            IsShowing = false;
        }
    }
}