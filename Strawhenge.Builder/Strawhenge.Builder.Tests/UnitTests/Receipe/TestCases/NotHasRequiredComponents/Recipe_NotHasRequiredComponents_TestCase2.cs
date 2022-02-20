﻿using System.Collections.Generic;

namespace Strawhenge.Builder.Tests.UnitTests
{
    internal class Recipe_NotHasRequiredComponents_TestCase2 : Recipe_NotHasRequiredComponents_TestCase
    {
        public override IEnumerable<ComponentQuantity> GetInventoryComponents()
        {
            yield return new ComponentQuantity(Components.Wood, 1);
            yield return new ComponentQuantity(Components.Plastic, 1);
        }

        public override IEnumerable<ComponentQuantity> GetRecipeComponents()
        {
            yield return new ComponentQuantity(Components.Metal, 1);
        }
    }
}
