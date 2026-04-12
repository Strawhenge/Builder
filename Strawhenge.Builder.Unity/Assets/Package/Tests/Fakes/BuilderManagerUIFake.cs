using System;

namespace Strawhenge.Builder.Unity.Tests.Fakes
{
    class BuilderManagerUIFake : IBuilderManagerUI
    {
        public event Action ExitBuilder;
        public event Action OpenMenu;

        internal bool IsEnabled { get; private set; }

        public void Show() => IsEnabled = true;

        public void Hide() => IsEnabled = false;

        internal void InvokeExitBuilder() => ExitBuilder?.Invoke();

        internal void InvokeOpenMenu() => OpenMenu?.Invoke();
    }
}
