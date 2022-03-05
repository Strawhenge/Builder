using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.UnitTests.ComponentInventoryTests
{
    public abstract class ComponentInventory_Tests
    {
        readonly ComponentInventory sut;

        protected ComponentInventory_Tests(ITestOutputHelper testOutputHelper)
        {
            sut = CreateSut(
                logger: new TestOutputLogger(testOutputHelper));
        }

        [Fact]
        public void CountTotal_ShouldBeExpectedValue()
        {
            PerformTest(sut);

            Assert.Equal(ExpectedTotalCount, sut.CountTotal());
        }

        [Fact]
        public void Count_ShouldBeExpectedValue()
        {
            PerformTest(sut);

            foreach (var (component, expectedCount) in GetExpectedCountsByComponent())
            {
                Assert.Equal(expectedCount, sut.Count(component));
            }
        }

        protected abstract int ExpectedTotalCount { get; }

        protected virtual ComponentInventory CreateSut(ILogger logger) => new ComponentInventory(logger);

        protected abstract void PerformTest(ComponentInventory sut);

        protected abstract IEnumerable<(Component component, int expectedCount)> GetExpectedCountsByComponent();
    }
}
