using System.Collections.Generic;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.UnitTests.ComponentInventoryTests
{
    public class ComponentInventory_TestCase11 : ComponentInventory_Tests
    {
        public ComponentInventory_TestCase11(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        protected override IEnumerable<(Component component, int expectedCount)> GetExpectedCountsByComponent()
        {
            yield return (Components.Wood, 2);
            yield return (Components.Metal, 0);
            yield return (Components.Plastic, 0);
        }

        protected override int ExpectedTotalCount => 2;

        protected override void PerformTest(ComponentInventory sut)
        {
            sut.AddComponent(Components.Wood, 3);
            sut.RemoveComponent(Components.Wood, 1);

            sut.InfiniteComponents = true;

            sut.RemoveComponent(Components.Wood, 1);

            sut.InfiniteComponents = false;
        }
    }
}
