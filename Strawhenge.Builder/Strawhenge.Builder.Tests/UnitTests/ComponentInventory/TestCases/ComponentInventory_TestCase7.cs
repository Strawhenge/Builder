﻿using System.Collections.Generic;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.UnitTests.ComponentInventoryTests
{
    public class ComponentInventory_TestCase7 : ComponentInventory_Tests
    {
        public ComponentInventory_TestCase7(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        protected override IEnumerable<(Component component, int expectedCount)> GetExpectedCountsByComponent()
        {
            yield return (Components.Wood, 2);
            yield return (Components.Metal, 1);
            yield return (Components.Plastic, 0);
        }

        protected override int ExpectedTotalCount => 3;

        protected override void PerformTest(ComponentInventory sut)
        {
            sut.AddComponent(Components.Wood, 2);
            sut.AddComponent(Components.Metal, 1);
            sut.AddComponent(Components.Plastic, 0);
        }
    }
}
