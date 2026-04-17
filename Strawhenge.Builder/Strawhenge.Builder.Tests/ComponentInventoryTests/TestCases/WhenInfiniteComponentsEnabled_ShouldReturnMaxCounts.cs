using System.Collections.Generic;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.ComponentInventoryTests.TestCases
{
    public class WhenInfiniteComponentsEnabled_ShouldReturnMaxCounts : BaseComponentInventoryTest
    {
        public WhenInfiniteComponentsEnabled_ShouldReturnMaxCounts(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
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

