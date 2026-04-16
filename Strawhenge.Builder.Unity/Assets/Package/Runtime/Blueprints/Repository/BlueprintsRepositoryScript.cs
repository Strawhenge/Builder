using FunctionalUtilities;
using Strawhenge.Builder.Unity.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Package.Runtime.Blueprints
{
    public abstract class BlueprintsRepositoryScript : MonoBehaviour, IBlueprintRepository
    {
        public abstract Maybe<IBlueprint> FindByName(string name);

        public abstract IReadOnlyList<IBlueprint> GetAll();
    }
}