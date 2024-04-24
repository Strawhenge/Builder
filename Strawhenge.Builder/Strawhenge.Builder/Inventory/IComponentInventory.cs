using System.Collections.Generic;

namespace Strawhenge.Builder
{
    public interface IComponentInventory
    {
        bool InfiniteComponents { get; set; }

        void AddComponent(Component component, int quantity);

        int CountTotal();

        int Count(Component component);

        IReadOnlyList<ComponentQuantity> GetComponents();

        void RemoveComponent(Component component, int quantity);

        void RemoveAllComponents();
    }
}