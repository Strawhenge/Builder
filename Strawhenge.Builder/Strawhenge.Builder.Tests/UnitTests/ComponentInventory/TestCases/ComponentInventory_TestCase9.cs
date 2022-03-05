﻿using System.Collections.Generic;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.UnitTests.ComponentInventoryTests
{
    public class ComponentInventory_TestCase9 : ComponentInventory_Tests
    {
        public ComponentInventory_TestCase9(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        protected override IEnumerable<(Component component, int expectedCount)> GetExpectedCountsByComponent()
        {
            yield return (Components.Wood, 9);
            yield return (Components.Metal, 0);
            yield return (Components.Plastic, 0);
        }

        protected override int ExpectedTotalCount => 9;

        protected override void PerformTest(ComponentInventory sut)
        {
            sut.AddComponent(Components.Wood, 10);
            sut.RemoveComponent(Components.Wood);
        }
    }
}
