using FunctionalUtilities;
using Strawhenge.Builder.Unity.ScriptableObjects;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity
{
    public interface IBlueprintRepository
    {
        Maybe<BlueprintScriptableObject> FindByName(string name);

        IReadOnlyList<BlueprintScriptableObject> GetAll();
    }
}