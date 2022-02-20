using System.Collections.Generic;

namespace Strawhenge.Builder.Tests.UnitTests
{
    internal class ComponentInventory_TestCase5 : ComponentInventory_TestCase
    {
        public override IEnumerable<(Component component, int expectedCount)> GetExpectedComponentCounts()
        {
            yield return (Components.Wood, 1);
            yield return (Components.Metal, 1);
            yield return (Components.Plastic, 1);
        }

        public override int GetExpectedTotalCount() => 3;

        protected override void PerformTest(ComponentInventory sut)
        {
            sut.AddComponent(Components.Wood);
            sut.AddComponent(Components.Metal);
            sut.AddComponent(Components.Plastic);
        }
    }
}
