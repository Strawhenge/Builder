using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.UnitTests
{
    public partial class RecipeTests
    {
        public static IEnumerable<object[]> HasRequiredComponents_ShouldBeTrue_TestCases =>
            HasRequiredComponents_TestCases
                .Select(x => new object[] { x.GetRecipeComponents(), x.GetInventoryComponents() });

        public static IEnumerable<object[]> HasRequiredComponents_ShouldBeFalse_TestCases =>
            NotHasRequiredComponents_TestCases
                .Select(x => new object[] { x.GetRecipeComponents(), x.GetInventoryComponents() });

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

        readonly ComponentInventory _inventory;

        public RecipeTests(ITestOutputHelper testOutputHelper)
        {
            _inventory = new ComponentInventory(
                new TestOutputLogger(testOutputHelper));
        }

        [Theory]
        [MemberData(nameof(HasRequiredComponents_ShouldBeTrue_TestCases))]
        public void HasRequiredComponents_ShouldBeTrue(IEnumerable<ComponentQuantity> recipeComponents,
            IEnumerable<ComponentQuantity> inventoryComponents)
        {
            _inventory.AddComponents(inventoryComponents);

            var sut = new Recipe(recipeComponents);

            Assert.True(
                sut.HasRequiredComponents(_inventory));
        }

        [Theory]
        [MemberData(nameof(HasRequiredComponents_ShouldBeFalse_TestCases))]
        public void HasRequiredComponents_ShouldBeFalse(IEnumerable<ComponentQuantity> recipeComponents,
            IEnumerable<ComponentQuantity> inventoryComponents)
        {
            _inventory.AddComponents(inventoryComponents);

            var sut = new Recipe(recipeComponents);

            Assert.False(
                sut.HasRequiredComponents(_inventory));
        }
    }
}