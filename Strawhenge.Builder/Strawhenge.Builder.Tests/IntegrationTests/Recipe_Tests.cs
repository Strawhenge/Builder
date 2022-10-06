using Autofac;
using Autofac.Extras.Moq;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.IntegrationTests
{
    public class Recipe_Tests
    {
        private readonly IComponentInventory inventory;

        public Recipe_Tests(ITestOutputHelper testOutputHelper)
        {
            var logger = new TestOutputLogger(testOutputHelper);

            var mocker = AutoMock.GetLoose(builder =>
            {
                builder.RegisterType<ComponentInventory>().As<IComponentInventory>().SingleInstance();
                builder.RegisterInstance(logger).As<ILogger>().SingleInstance();
            });

            inventory = mocker.Create<IComponentInventory>();
        }

        [Fact]
        public void Test()
        {
            var requiredComponents = new ComponentQuantity[]
            {
                Components.Metal.Quantity(5),
                Components.Plastic.Quantity(10)
            };

            var recipe = new Recipe(requiredComponents);

            Assert.False(
                recipe.HasRequiredComponents(inventory));

            var requirements = recipe.GetRequirements(inventory);

            Assert.Equal(2, requirements.Count());

            var metalRequirement = requirements.SingleOrDefault(x => x.Component.Is(Components.Metal));
            AssertRequirement(metalRequirement, 5, 0);

            var plasticRequirement = requirements.SingleOrDefault(x => x.Component.Is(Components.Plastic));
            AssertRequirement(plasticRequirement, 10, 0);

            inventory.AddComponent(Components.Metal, 10);
            inventory.AddComponent(Components.Plastic, 10);

            Assert.True(recipe.HasRequiredComponents(inventory));

            requirements = recipe.GetRequirements(inventory);

            metalRequirement = requirements.SingleOrDefault(x => x.Component.Is(Components.Metal));
            AssertRequirement(metalRequirement, 5, 10);

            plasticRequirement = requirements.SingleOrDefault(x => x.Component.Is(Components.Plastic));
            AssertRequirement(plasticRequirement, 10, 10);

            recipe.DeductRequiredComponents(inventory);

            Assert.False(recipe.HasRequiredComponents(inventory));

            requirements = recipe.GetRequirements(inventory);

            metalRequirement = requirements.SingleOrDefault(x => x.Component.Is(Components.Metal));
            AssertRequirement(metalRequirement, 5, 5);

            plasticRequirement = requirements.SingleOrDefault(x => x.Component.Is(Components.Plastic));
            AssertRequirement(plasticRequirement, 10, 0);
        }

        private void AssertRequirement(RecipeRequirement recipeRequirement, int expectedRequiredQuantity, int expectedInventoryQuantity)
        {
            Assert.NotNull(recipeRequirement);
            Assert.Equal(expectedRequiredQuantity, recipeRequirement.QuantityRequired);
            Assert.Equal(expectedInventoryQuantity, recipeRequirement.QuantityInInventory);
        }
    }
}
