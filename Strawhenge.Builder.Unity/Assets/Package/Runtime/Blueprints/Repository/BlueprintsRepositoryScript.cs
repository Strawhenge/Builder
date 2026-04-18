using FunctionalUtilities;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Blueprints.Repository
{
    public abstract class BlueprintsRepositoryScript : MonoBehaviour, IBlueprintRepository
    {
        public abstract Maybe<IBlueprint> FindByName(string name);

        public abstract IReadOnlyList<IBlueprint> GetAll();
    }
}