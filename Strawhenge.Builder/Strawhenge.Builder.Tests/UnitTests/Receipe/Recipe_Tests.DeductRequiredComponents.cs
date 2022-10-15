using Moq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Strawhenge.Builder.Tests.UnitTests
{
    public partial class Recipe_Tests
    {
        [Theory]
        [ClassData(typeof(DeductRequiredComponents_ShouldRemoveComponentsFromInventory_Data))]
        public void DeductRequiredComponents_ShouldRemoveComponentsFromInventory(
            IEnumerable<ComponentQuantity> recipeComponents)
        {
            var inventoryMock = new Mock<IComponentInventory>();

            var sut = new Recipe(recipeComponents);
            sut.DeductRequiredComponents(inventoryMock.Object);

            foreach (var componentQuantity in recipeComponents)
            {
                inventoryMock.Verify(
                    x => x.RemoveComponent(It.Is<Component>(y => y.Is(componentQuantity.Component)),
                        componentQuantity.Quantity),
                    Times.Once);
            }
        }

        class DeductRequiredComponents_ShouldRemoveComponentsFromInventory_Data : IEnumerable<object[]>
        {
            private IEnumerable<ComponentQuantity> GetComponents()
            {
                yield return new ComponentQuantity(Components.Metal, 2);
                yield return new ComponentQuantity(Components.Wood, 1);
                yield return new ComponentQuantity(Components.Plastic, 10);
            }

            public IEnumerator<object[]> GetEnumerator()
            {
                var components = GetComponents();
                var data = new object[] { components };

                return new[] { data }
                    .AsEnumerable()
                    .GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}