using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.UnitTests.Scrap
{
    public class ScrapValue_Tests
    {
        readonly ComponentInventory _inventory;

        public ScrapValue_Tests(ITestOutputHelper testOutputHelper)
        {
            var logger = new TestOutputLogger(testOutputHelper);

            _inventory = new ComponentInventory(logger);
        }

        [Fact]
        public void GetAdditions_WhenScrapValueIsEmpty_ShouldReturnEmpty()
        {
            var scrap = new ScrapValue(Enumerable.Empty<ComponentQuantity>());

            var additions = scrap.GetAdditions(_inventory);

            Assert.NotNull(additions);
            Assert.Empty(additions);
        }

        [Fact]
        public void GetAdditions_WhenScrapValueHasSingleComponent_ShouldReturnSingleAddition()
        {
            var component = Components.Wood.One();
            var scrap = new ScrapValue(component.Enumerate());

            var additions = scrap.GetAdditions(_inventory);

            Assert.NotNull(additions);
            var addition = Assert.Single(additions);

            VerifyAddition(addition, Components.Wood, expectedQuantity: 1, expectedInventoryQuantity: 0);
        }

        [Fact]
        public void GetAdditions_WhenScrapValueHasSingleComponent_AndInventoryAlreadyHasSome_ShouldReturnSingleAddition()
        {
            var component = Components.Wood.One();
            var scrap = new ScrapValue(component.Enumerate());

            const int inventoryQuantity = 5;
            _inventory.AddComponent(Components.Wood, 5);

            var additions = scrap.GetAdditions(_inventory);

            Assert.NotNull(additions);
            var addition = Assert.Single(additions);

            VerifyAddition(addition, Components.Wood, expectedQuantity: 1, expectedInventoryQuantity: inventoryQuantity);
        }

        [Fact]
        public void GetAdditions_ShouldReturnComponents()
        {
            var scrapComponents = new ComponentQuantitiesBuilder()
                .Add(Components.Plastic.One())
                .Add(Components.Wood.Five())
                .Build();

            var scrap = new ScrapValue(scrapComponents);

            _inventory.AddComponent(Components.Wood, 5);
            _inventory.AddComponent(Components.Metal, 5);

            var additions = scrap.GetAdditions(_inventory);
            Assert.NotNull(additions);
            Assert.Equal(2, additions.Count());

            var plasticAddition = Assert.Single(additions.Where(x => x.Component.Is(Components.Plastic)));
            VerifyAddition(plasticAddition, Components.Plastic, expectedQuantity: 1, expectedInventoryQuantity: 0);

            var woodAddition = Assert.Single(additions.Where(x => x.Component.Is(Components.Wood)));
            VerifyAddition(woodAddition, Components.Wood, expectedQuantity: 5, expectedInventoryQuantity: 5);
        }

        void VerifyAddition(ScrapAddition addition, Component expectedComponent, int expectedQuantity, int expectedInventoryQuantity)
        {
            Assert.True(addition.Component.Is(expectedComponent));
            Assert.Equal(expectedQuantity, addition.AdditionalQuantity);
            Assert.Equal(expectedInventoryQuantity, addition.QuantityInInventory);
        }
    }
}
