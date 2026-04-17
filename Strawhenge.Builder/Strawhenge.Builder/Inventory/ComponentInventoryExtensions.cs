using System.Collections.Generic;

namespace Strawhenge.Builder
{
    public static class ComponentInventoryExtensions
    {
        public static void AddComponent(this ComponentInventory inventory, Component component) =>
            inventory.AddComponent(component, 1);

        public static void AddComponent(this ComponentInventory inventory, ComponentQuantity componentQuantity) =>
            inventory.AddComponent(componentQuantity.Component, componentQuantity.Quantity);

        public static void AddComponents(
            this ComponentInventory inventory,
            IEnumerable<ComponentQuantity> components)
        {
            foreach (var componentQuantity in components)
                inventory.AddComponent(componentQuantity);
        }

        public static void RemoveComponent(this ComponentInventory inventory, Component component) =>
            inventory.RemoveComponent(component, 1);
    }
}