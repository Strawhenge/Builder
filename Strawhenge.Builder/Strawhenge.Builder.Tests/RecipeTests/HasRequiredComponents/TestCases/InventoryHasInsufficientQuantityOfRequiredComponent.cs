using System.Collections.Generic;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.RecipeTests.HasRequiredComponents.TestCases
{
    public class InventoryHasInsufficientQuantityOfRequiredComponent : BaseHasRequiredComponentsTest
    {
        public InventoryHasInsufficientQuantityOfRequiredComponent(ITestOutputHelper testOutputLogger) : base(testOutputLogger)
        {
        }
        
        protected override bool ShouldHaveRequiredComponents => false;

        public override IEnumerable<ComponentQuantity> GetInventoryComponents()
        {
            yield return new ComponentQuantity(Components.Wood, 1);
            yield return new ComponentQuantity(Components.Plastic, 1);
        }

        public override IEnumerable<ComponentQuantity> GetRecipeComponents()
        {
            yield return new ComponentQuantity(Components.Wood, 2);
        }
    }
}


