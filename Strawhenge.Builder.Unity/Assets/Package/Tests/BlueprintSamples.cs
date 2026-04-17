using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Builder.Unity.Tests.Fakes;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests
{
    static class BlueprintSamples
    {
        public static BlueprintFake Wall { get; } =
            new(
                nameof(Wall),
                new GameObject(nameof(Wall)).AddComponent<BuildItemScript>());

        public static class Furniture
        {
            public static string CategoryName => nameof(Furniture);

            public static BlueprintFake Chair { get; } =
                new(
                    nameof(Chair),
                    new GameObject(nameof(Chair)).AddComponent<BuildItemScript>(),
                    new Category(CategoryName));
        }
    }
}