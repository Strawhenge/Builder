using System.Collections.Generic;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.ComponentInventoryTests.TestCases
{
    public class WhenAddThenRemoveSameComponent_ShouldReturnToZero : BaseComponentInventoryTest
    {
        public WhenAddThenRemoveSameComponent_ShouldReturnToZero(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
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
            sut.AddComponent(Components.Wood);
            sut.RemoveComponent(Components.Wood);
        }
    }
}

