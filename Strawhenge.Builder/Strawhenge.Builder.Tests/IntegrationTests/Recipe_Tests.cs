using Autofac;
using Autofac.Extras.Moq;
using System.Linq;
using Strawhenge.Common.Logging;
using Xunit;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.IntegrationTests
{
    public class Recipe_Tests
    {
        private readonly IComponentInventory _inventory;

        public Recipe_Tests(ITestOutputHelper testOutputHelper)
        {
            var logger = new TestOutputLogger(testOutputHelper);

            var mocker = AutoMock.GetLoose(builder =>
            {
                builder.RegisterType<ComponentInventory>().As<IComponentInventory>().SingleInstance();
                builder.RegisterInstance(logger).As<ILogger>().SingleInstance();
            });

            _inventory = mocker.Create<IComponentInventory>();
        }

        [Fact]
        public void Test()
        {
            var requiredComponents = new[]
            {
                Components.Metal.Quantity(5),
                Components.Plastic.Quantity(10)
            };

            var recipe = new Recipe(requiredComponents);

            Assert.False(
                recipe.HasRequiredComponents(_inventory));

            var requirements = recipe.GetRequirements(_inventory);

            Assert.Equal(2, requirements.Count());

            var metalRequirement = requirements.SingleOrDefault(x => x.Component.Is(Components.Metal));
            AssertRequirement(metalRequirement, 5, 0);

            var plasticRequirement = requirements.SingleOrDefault(x => x.Component.Is(Components.Plastic));
            AssertRequirement(plasticRequirement, 10, 0);

            _inventory.AddComponent(Components.Metal, 10);
            _inventory.AddComponent(Components.Plastic, 10);

            Assert.True(recipe.HasRequiredComponents(_inventory));

            requirements = recipe.GetRequirements(_inventory);

            metalRequirement = requirements.SingleOrDefault(x => x.Component.Is(Components.Metal));
            AssertRequirement(metalRequirement, 5, 10);

            plasticRequirement = requirements.SingleOrDefault(x => x.Component.Is(Components.Plastic));
            AssertRequirement(plasticRequirement, 10, 10);

            recipe.DeductRequiredComponents(_inventory);

            Assert.False(recipe.HasRequiredComponents(_inventory));

            requirements = recipe.GetRequirements(_inventory);

            metalRequirement = requirements.SingleOrDefault(x => x.Component.Is(Components.Metal));
            AssertRequirement(metalRequirement, 5, 5);

            plasticRequirement = requirements.SingleOrDefault(x => x.Component.Is(Components.Plastic));
            AssertRequirement(plasticRequirement, 10, 0);
        }

        private void AssertRequirement(RecipeRequirement recipeRequirement, int expectedRequiredQuantity,
            int expectedInventoryQuantity)
        {
            Assert.NotNull(recipeRequirement);
            Assert.Equal(expectedRequiredQuantity, recipeRequirement.QuantityRequired);
            Assert.Equal(expectedInventoryQuantity, recipeRequirement.QuantityInInventory);
        }
    }
}