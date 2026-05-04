using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.RecipeTests.HasRequiredComponents
{
    public abstract class BaseHasRequiredComponentsTest
    {
        protected abstract bool ShouldHaveRequiredComponents { get; }

        public abstract IEnumerable<ComponentQuantity> GetRecipeComponents();

        public abstract IEnumerable<ComponentQuantity> GetInventoryComponents();

        readonly ComponentInventory _inventory;

        protected BaseHasRequiredComponentsTest(ITestOutputHelper testOutputLogger)
        {
            _inventory = new ComponentInventory(
                new TestOutputLogger(testOutputLogger));
        }

        [Fact]
        public void HasRequiredComponents()
        {
            _inventory.AddComponents(GetInventoryComponents());
            var recipe = new Recipe(GetRecipeComponents());

            var hasRequiredComponents = recipe.HasRequiredComponents(_inventory);

            if (ShouldHaveRequiredComponents)
                Assert.True(hasRequiredComponents);
            else
                Assert.False(hasRequiredComponents);
        }
    }
}