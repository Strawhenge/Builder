using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.RecipeTests.HasRequiredComponents.TestCases
{
    public class InventoryIsEmptyAndRecipeRequiresComponent : BaseHasRequiredComponentsTest
    {
        public InventoryIsEmptyAndRecipeRequiresComponent(ITestOutputHelper testOutputLogger) : base(testOutputLogger)
        {
        }

        protected override bool ShouldHaveRequiredComponents => false;

        public override IEnumerable<ComponentQuantity> GetInventoryComponents()
        {
            return Enumerable.Empty<ComponentQuantity>();
        }

        public override IEnumerable<ComponentQuantity> GetRecipeComponents()
        {
            yield return new ComponentQuantity(Components.Metal, 1);
        }
    }
}


