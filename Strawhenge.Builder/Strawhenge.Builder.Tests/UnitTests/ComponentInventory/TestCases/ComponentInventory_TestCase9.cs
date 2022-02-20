using System.Collections.Generic;

namespace Strawhenge.Builder.Tests.UnitTests
{
    internal class ComponentInventory_TestCase9 : ComponentInventory_TestCase
    {
        public override IEnumerable<(Component component, int expectedCount)> GetExpectedComponentCounts()
        {
            yield return (Components.Wood, 9);
            yield return (Components.Metal, 0);
            yield return (Components.Plastic, 0);
        }

        public override int GetExpectedTotalCount() => 9;

        protected override void PerformTest(ComponentInventory sut)
        {
            sut.AddComponent(Components.Wood, 10);
            sut.RemoveComponent(Components.Wood);
        }
    }
}
