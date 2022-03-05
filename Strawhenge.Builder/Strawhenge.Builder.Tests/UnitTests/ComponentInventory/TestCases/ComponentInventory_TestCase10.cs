using System.Collections.Generic;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.UnitTests.ComponentInventoryTests
{
    public class ComponentInventory_TestCase10 : ComponentInventory_Tests
    {
        public ComponentInventory_TestCase10(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        protected override IEnumerable<(Component component, int expectedCount)> GetExpectedCountsByComponent()
        {
            yield return (Components.Wood, int.MaxValue);
            yield return (Components.Metal, int.MaxValue);
            yield return (Components.Plastic, int.MaxValue);
        }

        protected override int ExpectedTotalCount => int.MaxValue;

        protected override void PerformTest(ComponentInventory sut)
        {
            sut.InfiniteComponents = true;
        }
    }
}
