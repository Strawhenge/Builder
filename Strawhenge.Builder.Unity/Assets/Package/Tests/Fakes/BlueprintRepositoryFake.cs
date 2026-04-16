using FunctionalUtilities;
using Strawhenge.Builder.Unity.ScriptableObjects;
using System;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.Tests.Fakes
{
    class BlueprintRepositoryFake : IBlueprintRepository
    {
        public List<IBlueprint> Blueprints { get; private set; } = new();
        
        public Maybe<IBlueprint> FindByName(string name)
        {
            return Blueprints.FirstOrNone(x => x.Name == name);
        }

        public IReadOnlyList<IBlueprint> GetAll()
        {
            return Blueprints;
        }
    }
}