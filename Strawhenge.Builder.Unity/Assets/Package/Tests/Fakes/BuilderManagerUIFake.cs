using System;

namespace Strawhenge.Builder.Unity.Tests.Fakes
{
    class BuilderManagerUIFake : IBuilderManagerUI
    {
        public event Action ExitedBuilder;
        public event Action OpenedMenu;

        internal bool IsEnabled { get; private set; }

        public void Show() => IsEnabled = true;

        public void Hide() => IsEnabled = false;

        internal void InvokeExitBuilder() => ExitedBuilder?.Invoke();

        internal void InvokeOpenMenu() => OpenedMenu?.Invoke();
    }
}
