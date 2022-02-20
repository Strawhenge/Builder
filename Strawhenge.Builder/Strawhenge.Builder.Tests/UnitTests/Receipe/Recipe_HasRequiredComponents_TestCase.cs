using System.Collections.Generic;

namespace Strawhenge.Builder.Tests.UnitTests
{
    internal abstract class Recipe_HasRequiredComponents_TestCase
    {
        public abstract IEnumerable<ComponentQuantity> GetRecipeComponents();

        public abstract IEnumerable<ComponentQuantity> GetInventoryComponents();
    }
}
