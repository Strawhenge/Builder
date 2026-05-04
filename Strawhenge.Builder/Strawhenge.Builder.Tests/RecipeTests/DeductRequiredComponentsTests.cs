using Xunit;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.RecipeTests
{
    public class DeductRequiredComponents
    {
        readonly ComponentInventory _inventory;

        public DeductRequiredComponents(ITestOutputHelper testOutputLogger)
        {
            _inventory = new ComponentInventory(
                new TestOutputLogger(testOutputLogger));
        }

        [Fact]
        public void DeductRequiredComponents_ShouldRemoveComponentsFromInventory()
        {
            const int initialMetal = 10;
            const int initialWood = 10;
            const int initialPlastic = 10;

            _inventory.AddComponent(Components.Metal, initialMetal);
            _inventory.AddComponent(Components.Wood, initialWood);
            _inventory.AddComponent(Components.Plastic, initialPlastic);

            const int requiredMetal = 2;
            const int requiredWood = 1;
            const int requiredPlastic = 10;

            var requirements = new[]
            {
                new ComponentQuantity(Components.Metal, requiredMetal),
                new ComponentQuantity(Components.Wood, requiredWood),
                new ComponentQuantity(Components.Plastic, requiredPlastic)
            };

            var sut = new Recipe(requirements);
            sut.DeductRequiredComponents(_inventory);

            Assert.Equal(_inventory.Count(Components.Metal), initialMetal - requiredMetal);
            Assert.Equal(_inventory.Count(Components.Wood), initialWood - requiredWood);
            Assert.Equal(_inventory.Count(Components.Plastic), initialPlastic - requiredPlastic);
        }
    }
}