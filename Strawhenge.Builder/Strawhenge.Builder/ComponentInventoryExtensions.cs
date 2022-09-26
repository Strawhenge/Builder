namespace Strawhenge.Builder
{
    public static class ComponentInventoryExtensions
    {
        public static void AddComponent(this IComponentInventory inventory, ComponentQuantity componentQuantity) =>
            inventory.AddComponent(componentQuantity.Component, componentQuantity.Quantity);
    }
}
