using System.Collections.Generic;

namespace Strawhenge.Builder.Tests.UnitTests
{
    internal class ComponentInventory_TestCase7 : ComponentInventory_TestCase
    {
        public override IEnumerable<(Component component, int expectedCount)> GetExpectedComponentCounts()
        {
            yield return (Components.Wood, 2);
            yield return (Components.Metal, 1);
            yield return (Components.Plastic, 0);
        }

        public override int GetExpectedTotalCount() => 3;

        protected override void PerformTest(ComponentInventory sut)
        {
            sut.AddComponent(Components.Wood, 2);
            sut.AddComponent(Components.Metal, 1);
            sut.AddComponent(Components.Plastic, 0);
        }
    }
}
