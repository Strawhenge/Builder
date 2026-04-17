using System.Collections.Generic;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.RecipeTests.HasRequiredComponents.TestCases
{
    public class InventoryExactlyMatchesSingleRequirement : BaseHasRequiredComponentsTest
    {
        public InventoryExactlyMatchesSingleRequirement(ITestOutputHelper testOutputLogger) : base(testOutputLogger)
        {
        }

        protected override bool ShouldHaveRequiredComponents => true;
        
        public override IEnumerable<ComponentQuantity> GetInventoryComponents()
        {
            yield return new ComponentQuantity(Components.Wood, 2);
        }

        public override IEnumerable<ComponentQuantity> GetRecipeComponents()
        {
            yield return new ComponentQuantity(Components.Wood, 2);
        }
    }
}


