using FunctionalUtilities;
using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity.Data;
using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Builder.Unity.ScriptableObjects;
using System;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.Tests.Fakes
{
    class BlueprintFake : IBlueprint
    {
        public BlueprintFake(string name, BuildItemScript buildItem, ICategory category = null)
        {
            Name = name;
            BuildItem = buildItem;
            Category = Maybe.NotNull(category);
            Recipe = Array.Empty<SerializableComponentQuantity>();
        }


        public string Name { get; }

        public Maybe<ICategory> Category { get; }

        public BuildItemScript BuildItem { get; }

        public IReadOnlyList<SerializableComponentQuantity> Recipe { get; }
    }
}