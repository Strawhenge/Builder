namespace Strawhenge.Builder
{
    public class RecipeRequirement
    {
        public RecipeRequirement(Component component, int quantityRequired, int quantityInInventory)
        {
            Component = component;
            QuantityRequired = quantityRequired;
            QuantityInInventory = quantityInInventory;
        }

        public Component Component { get; }

        public int QuantityRequired { get; }

        public int QuantityInInventory { get; }

        public bool HasRequiredAmount => QuantityInInventory >= QuantityRequired;
    }
}
