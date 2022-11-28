using Strawhenge.Builder.Unity.Monobehaviours;
using System;

namespace Strawhenge.Builder.Unity.Tests.Fakes
{
    class BuildItemScriptSelectorFake : IBuildItemScriptSelector
    {
        public event Action<BuildItemScript> Select;

        public void Enable() => IsEnabled = true;

        public void Disable() => IsEnabled = false;

        internal bool IsEnabled { get; private set; }

        internal void InvokeSelect(BuildItemScript buildItem) => Select?.Invoke(buildItem);
    }
}