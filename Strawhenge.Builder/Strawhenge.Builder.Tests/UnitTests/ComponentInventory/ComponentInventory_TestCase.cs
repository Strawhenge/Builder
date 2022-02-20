using Moq;
using System;
using System.Collections.Generic;

namespace Strawhenge.Builder.Tests.UnitTests
{
    internal abstract class ComponentInventory_TestCase
    {
        public IMock<ILogger> LoggerMock { get; } = new Mock<ILogger>();

        public virtual ComponentInventory CreateSut() => new ComponentInventory(LoggerMock.Object);

        public Action<ComponentInventory> GetTestAction() => PerformTest;

        public abstract int GetExpectedTotalCount();

        public abstract IEnumerable<(Component component, int expectedCount)> GetExpectedComponentCounts();

        protected abstract void PerformTest(ComponentInventory sut);
    }
}
