using System.Collections.Generic;

namespace Strawhenge.Builder.Tests.UnitTests
{
    internal class ComponentInventory_TestCase3 : ComponentInventory_TestCase
    {
        public override IEnumerable<(Component component, int expectedCount)> GetExpectedComponentCounts()
        {
            yield return (Components.Wood, 0);
            yield return (Components.Metal, 0);
            yield return (Components.Plastic, 0);
        }

        public override int GetExpectedTotalCount() => 0;

        protected override void PerformTest(ComponentInventory sut)
        {
            sut.AddComponent(Components.Wood);
            sut.RemoveComponent(Components.Wood);
        }
    }
}
