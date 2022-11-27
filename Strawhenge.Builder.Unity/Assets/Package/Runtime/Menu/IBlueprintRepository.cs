using Strawhenge.Builder.Unity.ScriptableObjects;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity
{
    public interface IBlueprintRepository
    {
        IReadOnlyList<BlueprintScriptableObject> GetAll();
    }
}