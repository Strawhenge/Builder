using FunctionalUtilities;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.Blueprints.Repository
{
    public interface IBlueprintRepository
    {
        Maybe<IBlueprint> FindByName(string name);

        IReadOnlyList<IBlueprint> GetAll();
    }
}