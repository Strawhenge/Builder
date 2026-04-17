using System.Collections.Generic;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.RecipeTests.HasRequiredComponents.TestCases
{
    public class InventoryContainsRequiredComponentAndExtras : BaseHasRequiredComponentsTest
    {
        public InventoryContainsRequiredComponentAndExtras(ITestOutputHelper testOutputLogger) : base(testOutputLogger)
        {
        }

        protected override bool ShouldHaveRequiredComponents => true;
        
        public override IEnumerable<ComponentQuantity> GetInventoryComponents()
        {
            yield return new ComponentQuantity(Components.Metal, 4);
            yield return new ComponentQuantity(Components.Wood, 2);
            yield return new ComponentQuantity(Components.Plastic, 2);
        }

        public override IEnumerable<ComponentQuantity> GetRecipeComponents()
        {
            yield return new ComponentQuantity(Components.Wood, 2);
        }
    }
}


