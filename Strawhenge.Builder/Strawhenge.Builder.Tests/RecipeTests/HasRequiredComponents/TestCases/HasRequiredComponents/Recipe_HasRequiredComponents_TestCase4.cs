using System.Collections.Generic;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.RecipeTests.HasRequiredComponents.TestCases.HasRequiredComponents
{
    public class Recipe_HasRequiredComponents_TestCase4 : BaseHasRequiredComponentsTest
    {
        public Recipe_HasRequiredComponents_TestCase4(ITestOutputHelper testOutputLogger) : base(testOutputLogger)
        {
        }

        protected override bool ShouldHaveRequiredComponents => true;
        
        public override IEnumerable<ComponentQuantity> GetInventoryComponents()
        {
            yield return new ComponentQuantity(Components.Metal, 10);
            yield return new ComponentQuantity(Components.Wood, 2);
            yield return new ComponentQuantity(Components.Plastic, 30);
        }

        public override IEnumerable<ComponentQuantity> GetRecipeComponents()
        {
            yield return new ComponentQuantity(Components.Wood, 2);
            yield return new ComponentQuantity(Components.Plastic, 5);
            yield return new ComponentQuantity(Components.Metal, 2);
        }
    }
}
