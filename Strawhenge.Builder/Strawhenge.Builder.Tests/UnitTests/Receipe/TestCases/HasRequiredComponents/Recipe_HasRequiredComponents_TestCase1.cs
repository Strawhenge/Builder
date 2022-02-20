using System.Collections.Generic;
using System.Linq;

namespace Strawhenge.Builder.Tests.UnitTests
{
    internal class Recipe_HasRequiredComponents_TestCase1 : Recipe_HasRequiredComponents_TestCase
    {
        public override IEnumerable<ComponentQuantity> GetInventoryComponents()
        {
            return Enumerable.Empty<ComponentQuantity>();
        }

        public override IEnumerable<ComponentQuantity> GetRecipeComponents()
        {
            return Enumerable.Empty<ComponentQuantity>();
        }
    }
}
