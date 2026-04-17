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

        public void InvokeSelectItem(string item) => SelectItem?.Invoke(item);

        public void InvokeSelectExit() => SelectExit?.Invoke();

        void IMenuView.Show(IReadOnlyList<string> categories, IReadOnlyList<string> items, bool enableBack)
        {
            IsShowing = true;
        }

        void IMenuView.Hide()
        {
            IsShowing = false;
        }
    }
}