using System.Collections.Generic;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.UnitTests.ComponentInventoryTests
{
    public class ComponentInventory_TestCase05 : ComponentInventory_Tests
    {
        public ComponentInventory_TestCase05(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        protected override IEnumerable<(Component component, int expectedCount)> GetExpectedCountsByComponent()
        {
            yield return (Components.Wood, 1);
            yield return (Components.Metal, 1);
            yield return (Components.Plastic, 1);
        }

        protected override int ExpectedTotalCount => 3;

        protected override void PerformTest(ComponentInventory sut)
        {
            sut.AddComponent(Components.Wood);
            sut.AddComponent(Components.Metal);
            sut.AddComponent(Components.Plastic);
        }
    }
}
