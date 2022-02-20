using System.Collections.Generic;

namespace Strawhenge.Builder.Tests.UnitTests
{
    internal abstract class Recipe_NotHasRequiredComponents_TestCase
    {
        public abstract IEnumerable<ComponentQuantity> GetRecipeComponents();

        public abstract IEnumerable<ComponentQuantity> GetInventoryComponents();
    }
}
