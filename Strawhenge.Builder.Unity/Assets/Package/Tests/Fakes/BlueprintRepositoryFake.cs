using FunctionalUtilities;
using Strawhenge.Builder.Unity.ScriptableObjects;
using System;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.Tests.Fakes
{
    public class BlueprintRepositoryFake : IBlueprintRepository
    {
        public Maybe<BlueprintScriptableObject> FindByName(string name)
        {
            return Maybe.None<BlueprintScriptableObject>();
        }

        public IReadOnlyList<BlueprintScriptableObject> GetAll()
        {
            return Array.Empty<BlueprintScriptableObject>();
        }
    }
}