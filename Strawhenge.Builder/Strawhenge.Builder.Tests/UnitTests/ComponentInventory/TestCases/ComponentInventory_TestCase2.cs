using System.Collections.Generic;

namespace Strawhenge.Builder.Tests.UnitTests
{
    internal class ComponentInventory_TestCase2 : ComponentInventory_TestCase
    {
        public override IEnumerable<(Component component, int expectedCount)> GetExpectedComponentCounts()
        {
            yield return (Components.Wood, 1);
            yield return (Components.Metal, 0);
            yield return (Components.Plastic, 0);
        }

        public override int GetExpectedTotalCount() => 1;

        protected override void PerformTest(ComponentInventory sut)
        {
            sut.AddComponent(Components.Wood);
        }
    }
}
