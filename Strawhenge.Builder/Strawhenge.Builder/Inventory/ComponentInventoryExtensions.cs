namespace Strawhenge.Builder
{
    public static class ComponentInventoryExtensions
    {
        public static void AddComponent(this IComponentInventory inventory, Component component) =>
            inventory.AddComponent(component, 1);

        public static void AddComponent(this IComponentInventory inventory, ComponentQuantity componentQuantity) =>
            inventory.AddComponent(componentQuantity.Component, componentQuantity.Quantity);

        public static void RemoveComponent(this IComponentInventory inventory, Component component) =>
            inventory.RemoveComponent(component, 1);
    }
}
