using System.Collections.Generic;

namespace Strawhenge.Builder
{
    public class RecipeFactory
    {
        public Recipe Create(params ComponentQuantity[] requiredComponents) =>
            Create(requiredComponents as IEnumerable<ComponentQuantity>);

        public Recipe Create(IEnumerable<ComponentQuantity> requiredComponents)
        {
            return new Recipe(requiredComponents);
        }
    }
}
