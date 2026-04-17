using System.Collections.Generic;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests.RecipeTests.HasRequiredComponents.TestCases
{
    public class Recipe_NotHasRequiredComponents_TestCase4 : BaseHasRequiredComponentsTest
    {
        public Recipe_NotHasRequiredComponents_TestCase4(ITestOutputHelper testOutputLogger) : base(testOutputLogger)
        {
        }

        protected override bool ShouldHaveRequiredComponents => false;

        public override IEnumerable<ComponentQuantity> GetInventoryComponents()
        {
            yield return new ComponentQuantity(Components.Wood, 2);
            yield return new ComponentQuantity(Components.Metal, 1);
        }

        public override IEnumerable<ComponentQuantity> GetRecipeComponents()
        {
            yield return new ComponentQuantity(Components.Metal, 2);
            yield return new ComponentQuantity(Components.Wood, 2);
        }
    }
}