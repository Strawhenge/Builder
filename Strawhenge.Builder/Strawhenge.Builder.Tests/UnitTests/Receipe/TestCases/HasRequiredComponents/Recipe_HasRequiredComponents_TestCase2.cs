using System.Collections.Generic;

namespace Strawhenge.Builder.Tests.UnitTests
{
    internal class Recipe_HasRequiredComponents_TestCase2 : Recipe_HasRequiredComponents_TestCase
    {
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
