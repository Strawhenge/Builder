using Strawhenge.Builder.Unity.Blueprints;
using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Builder.Unity.ScriptableObjects;
using System;

namespace Strawhenge.Builder.Unity.Tests.Fakes
{
    class BlueprintFactoryFake : IBlueprintFactory
    {
        public Blueprint Create(BlueprintScriptableObject scriptableObject)
        {
            return new Blueprint(
                "test blueprint",
                new NullBuildItem(),
                new Recipe(Array.Empty<ComponentQuantity>()));
        }

        public ExistingBlueprint Create(BuildItemScript script)
        {
            return new ExistingBlueprint(
                "test blueprint",
                new NullBuildItem(),
                new ScrapValue(Array.Empty<ComponentQuantity>()));
        }
    }
}
