using Strawhenge.Builder.Unity.ScriptableObjects;
using System;

namespace Strawhenge.Builder.Unity
{
    public interface IBlueprintScriptableObjectMenu
    {
        event Action<IBlueprint> Select;
        event Action Exit;

        void Open();

        void Close();
    }
}