using FunctionalUtilities;
using Strawhenge.Builder.Unity.ScriptableObjects;
using System;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.Tests.Fakes
{
    public class BlueprintRepositoryFake : IBlueprintRepository
    {
        public Maybe<IBlueprint> FindByName(string name)
        {
            return Maybe.None<IBlueprint>();
        }

        public IReadOnlyList<IBlueprint> GetAll()
        {
            return Array.Empty<BlueprintScriptableObject>();
        }
    }
}