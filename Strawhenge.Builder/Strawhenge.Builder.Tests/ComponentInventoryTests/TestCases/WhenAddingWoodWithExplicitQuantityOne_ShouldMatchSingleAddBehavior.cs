using System.Collections.Generic;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.ComponentInventoryTests.TestCases
{
    public class WhenAddingWoodWithExplicitQuantityOne_ShouldMatchSingleAddBehavior : BaseComponentInventoryTest
    {
        public WhenAddingWoodWithExplicitQuantityOne_ShouldMatchSingleAddBehavior(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
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

