using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Strawhenge.Builder.Tests.UnitTests
{
    public class ComponentInventory_Tests
    {
        public static IEnumerable<object[]> CountTotal_ShouldBeExpectedValue_TestCases => testCases
            .Select(x => new object[] { x.CreateSut(), x.GetTestAction(), x.GetExpectedTotalCount() });

        [Theory]
        [MemberData(nameof(CountTotal_ShouldBeExpectedValue_TestCases))]
        public void CountTotal_ShouldBeExpectedValue(ComponentInventory sut, Action<ComponentInventory> testAction, int expectedCount)
        {
            testAction(sut);

            Assert.Equal(expectedCount, sut.CountTotal());
        }

        public static IEnumerable<object[]> Count_ShouldBeExpectedValue_TestCases => testCases
            .Select(x => new object[] { x.CreateSut(), x.GetTestAction(), x.GetExpectedComponentCounts() });

        [Theory]
        [MemberData(nameof(Count_ShouldBeExpectedValue_TestCases))]
        public void Count_ShouldBeExpectedValue(
            ComponentInventory sut,
            Action<ComponentInventory> testAction,
            IEnumerable<(Component component, int expectedCount)> expectedCountsByComponent)
        {
            testAction(sut);

            foreach (var (component, expectedCount) in expectedCountsByComponent)
            {
                Assert.Equal(expectedCount, sut.Count(component));
            }
        }

        private static readonly ComponentInventory_TestCase[] testCases = new ComponentInventory_TestCase[]
        {
            new ComponentInventory_TestCase1(),
            new ComponentInventory_TestCase2(),
            new ComponentInventory_TestCase3(),
            new ComponentInventory_TestCase4(),
            new ComponentInventory_TestCase5(),
            new ComponentInventory_TestCase6(),
            new ComponentInventory_TestCase7(),
            new ComponentInventory_TestCase8(),
            new ComponentInventory_TestCase9(),
        };
    }
}
