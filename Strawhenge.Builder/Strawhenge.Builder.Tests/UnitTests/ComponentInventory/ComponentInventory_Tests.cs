using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.UnitTests.ComponentInventoryTests
{
    public abstract class ComponentInventory_Tests
    {
        readonly ComponentInventory _sut;

        protected ComponentInventory_Tests(ITestOutputHelper testOutputHelper)
        {
            _sut = new ComponentInventory(
                logger: new TestOutputLogger(testOutputHelper));
        }

        [Fact]
        public void CountTotal_ShouldBeExpectedValue()
        {
            PerformTest(_sut);

            Assert.Equal(ExpectedTotalCount, _sut.CountTotal());
        }

        [Fact]
        public void Count_ShouldBeExpectedValue()
        {
            PerformTest(_sut);

            foreach (var (component, expectedCount) in GetExpectedCountsByComponent())
            {
                Assert.Equal(expectedCount, _sut.Count(component));
            }
        }

        protected abstract int ExpectedTotalCount { get; }

        protected abstract void PerformTest(ComponentInventory sut);

        protected abstract IEnumerable<(Component component, int expectedCount)> GetExpectedCountsByComponent();
    }
}