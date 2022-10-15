using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Strawhenge.Builder.Tests.UnitTests
{
    public partial class Recipe_Tests
    {
        public static IEnumerable<object[]> HasRequiredComponents_ShouldBeTrue_TestCases =>
            HasRequiredComponents_TestCases
                .Select(x => new object[] { x.GetRecipeComponents(), x.GetInventoryComponents() });

        [Theory]
        [MemberData(nameof(HasRequiredComponents_ShouldBeTrue_TestCases))]
        public void HasRequiredComponents_ShouldBeTrue(IEnumerable<ComponentQuantity> recipeComponents,
            IEnumerable<ComponentQuantity> inventoryComponents)
        {
            var inventoryMock = CreateInventoryMock(inventoryComponents);

            var sut = new Recipe(recipeComponents);

            Assert.True(
                sut.HasRequiredComponents(inventoryMock.Object));
        }

        public static IEnumerable<object[]> HasRequiredComponents_ShouldBeFalse_TestCases =>
            NotHasRequiredComponents_TestCases
                .Select(x => new object[] { x.GetRecipeComponents(), x.GetInventoryComponents() });

        [Theory]
        [MemberData(nameof(HasRequiredComponents_ShouldBeFalse_TestCases))]
        public void HasRequiredComponents_ShouldBeFalse(IEnumerable<ComponentQuantity> recipeComponents,
            IEnumerable<ComponentQuantity> inventoryComponents)
        {
            var inventoryMock = CreateInventoryMock(inventoryComponents);

            var sut = new Recipe(recipeComponents);

            Assert.False(
                sut.HasRequiredComponents(inventoryMock.Object));
        }

        Mock<IComponentInventory> CreateInventoryMock(IEnumerable<ComponentQuantity> inventoryComponents)
        {
            var inventoryMock = new Mock<IComponentInventory>();

            foreach (var componentQuantity in inventoryComponents)
            {
                inventoryMock
                    .Setup(x => x.Count(It.Is<Component>(y => y.Is(componentQuantity.Component))))
                    .Returns(componentQuantity.Quantity);
            }

            return inventoryMock;
        }

        static readonly Recipe_HasRequiredComponents_TestCase[] HasRequiredComponents_TestCases =
        {
            new Recipe_HasRequiredComponents_TestCase1(),
            new Recipe_HasRequiredComponents_TestCase2(),
            new Recipe_HasRequiredComponents_TestCase3(),
            new Recipe_HasRequiredComponents_TestCase4(),
            new Recipe_HasRequiredComponents_TestCase5(),
        };

        static readonly Recipe_NotHasRequiredComponents_TestCase[] NotHasRequiredComponents_TestCases =
        {
            new Recipe_NotHasRequiredComponents_TestCase1(),
            new Recipe_NotHasRequiredComponents_TestCase2(),
            new Recipe_NotHasRequiredComponents_TestCase3(),
            new Recipe_NotHasRequiredComponents_TestCase4(),
        };
    }
}