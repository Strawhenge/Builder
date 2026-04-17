using System.Collections.Generic;

namespace Strawhenge.Builder.Tests.UnitTests
{
    internal class Recipe_HasRequiredComponents_TestCase4 : Recipe_HasRequiredComponents_TestCase
    {
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
