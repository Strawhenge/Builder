using System;
using Xunit;

namespace Strawhenge.Builder.Tests.UnitTests
{
    public class ComponentExtensions_Tests
    {
        readonly Component _component = Components.Metal;

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(int.MaxValue)]
        public void Quantity_ShouldReturnComponentQuantity(int quantity)
        {
            var componentQuantity = _component.Quantity(quantity);

            Assert.NotNull(componentQuantity);
            Assert.Equal(quantity, componentQuantity.Quantity);
            Assert.NotNull(componentQuantity.Component);
            Assert.True(
                componentQuantity.Component.Is(_component));
        }

        [Fact]
        public void Quantity_WhenComponentIsNull_ShouldThrow()
        {
            Component component = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                component.Quantity(1);
            });
        }
    }
}