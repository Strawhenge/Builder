namespace Strawhenge.Builder
{
    public interface IComponentInventory
    {
        bool InfiniteComponents { get; set; }

        void AddComponent(Component component, int quantity);

        int Count(Component component);

        int CountTotal();

        void RemoveComponent(Component component, int quantity);

        void RemoveAllComponents();
    }
}