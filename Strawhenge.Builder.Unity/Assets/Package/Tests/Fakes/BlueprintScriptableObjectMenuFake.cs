using Strawhenge.Builder.Unity.ScriptableObjects;
using System;

namespace Strawhenge.Builder.Unity.Tests.Fakes
{
    class BlueprintScriptableObjectMenuFake : IBlueprintScriptableObjectMenu
    {
        public event Action<BlueprintScriptableObject> Select;
        public event Action Exit;

        internal bool IsOpen { get; private set; }

        public void Open() => IsOpen = true;

        public void Close() => IsOpen = false;

        internal void InvokeExit() => Exit?.Invoke();

        internal void InvokeSelect(BlueprintScriptableObject blueprint) => Select?.Invoke(blueprint);
    }
}
