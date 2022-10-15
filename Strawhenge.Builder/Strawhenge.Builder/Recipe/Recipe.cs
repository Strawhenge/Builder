using System.Collections.Generic;
using System.Linq;

namespace Strawhenge.Builder
{
    public class Recipe
    {
        readonly ComponentQuantity[] _requiredComponents;

        public Recipe(IEnumerable<ComponentQuantity> requiredComponents)
        {
            _requiredComponents = requiredComponents.ToArray();
        }

        public void DeductRequiredComponents(IComponentInventory inventory)
        {
            foreach (var requiredComponent in _requiredComponents)
            {
                inventory.RemoveComponent(
                    requiredComponent.Component,
                    requiredComponent.Quantity);
            }
        }

        public IEnumerable<RecipeRequirement> GetRequirements(IComponentInventory inventory)
        {
            return _requiredComponents
                .Select(ConvertToRequirement)
                .ToArray();

            RecipeRequirement ConvertToRequirement(ComponentQuantity componentQuantity)
            {
                var quantityInInventory = inventory.Count(componentQuantity.Component);

                return new RecipeRequirement(
                    componentQuantity.Component,
                    componentQuantity.Quantity,
                    quantityInInventory);
            }
        }

        public bool HasRequiredComponents(IComponentInventory inventory)
        {
            return GetRequirements(inventory)
                .All(x => x.HasRequiredAmount);
        }
    }
}
