using System;

namespace Strawhenge.Builder.Unity.Tests.Fakes
{
    class BuilderManagerUIFake : IBuilderManagerUI
    {
        public event Action ExitBuilder;
        public event Action OpenMenu;

        internal bool IsEnabled { get; private set; }

        public void Enable() => IsEnabled = true;

        public void Disable() => IsEnabled = false;

        internal void InvokeExitBuilder() => ExitBuilder?.Invoke();

        internal void InvokeOpenMenu() => OpenMenu?.Invoke();
    }
}
