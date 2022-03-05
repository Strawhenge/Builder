using System.Collections.Generic;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.UnitTests.ComponentInventoryTests
{
    public class ComponentInventory_TestCase06 : ComponentInventory_Tests
    {
        public ComponentInventory_TestCase06(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        protected override IEnumerable<(Component component, int expectedCount)> GetExpectedCountsByComponent()
        {
            yield return (Components.Wood, 1);
            yield return (Components.Metal, 0);
            yield return (Components.Plastic, 0);
        }

        protected override int ExpectedTotalCount => 1;

        protected override void PerformTest(ComponentInventory sut)
        {
            sut.AddComponent(Components.Wood, 1);
        }
    }
}
