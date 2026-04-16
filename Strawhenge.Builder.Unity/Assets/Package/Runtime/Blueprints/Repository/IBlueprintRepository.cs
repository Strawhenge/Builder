using FunctionalUtilities;
using Strawhenge.Builder.Unity.ScriptableObjects;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity
{
    public interface IBlueprintRepository
    {
        Maybe<IBlueprint> FindByName(string name);

        IReadOnlyList<IBlueprint> GetAll();
    }
}