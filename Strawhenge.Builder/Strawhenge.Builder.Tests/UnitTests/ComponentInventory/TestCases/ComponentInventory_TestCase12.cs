using System.Collections.Generic;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.UnitTests.ComponentInventoryTests
{
    public class ComponentInventory_TestCase12 : ComponentInventory_Tests
    {
        public ComponentInventory_TestCase12(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        protected override IEnumerable<(Component component, int expectedCount)> GetExpectedCountsByComponent()
        {
            yield return (Components.Wood, 0);
            yield return (Components.Metal, 0);
            yield return (Components.Plastic, 0);
        }

        protected override int ExpectedTotalCount => 0;

        protected override void PerformTest(ComponentInventory sut)
        {
            sut.AddComponent(Components.Wood, 3);
            sut.AddComponent(Components.Metal, 3);
            sut.AddComponent(Components.Plastic, 3);

            sut.RemoveAllComponents();
        }
    }
}