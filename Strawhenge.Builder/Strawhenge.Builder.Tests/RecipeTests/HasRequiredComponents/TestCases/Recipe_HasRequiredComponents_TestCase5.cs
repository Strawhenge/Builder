using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.RecipeTests.HasRequiredComponents.TestCases
{
    public class Recipe_HasRequiredComponents_TestCase5 : BaseHasRequiredComponentsTest
    {
        public Recipe_HasRequiredComponents_TestCase5(ITestOutputHelper testOutputLogger) : base(testOutputLogger)
        {
        }

        protected override bool ShouldHaveRequiredComponents => true;
        
        public override IEnumerable<ComponentQuantity> GetInventoryComponents()
        {
            return Enumerable.Empty<ComponentQuantity>();
        }

        public override IEnumerable<ComponentQuantity> GetRecipeComponents()
        {
            yield return new ComponentQuantity(Components.Wood, 0);
        }
    }
}
