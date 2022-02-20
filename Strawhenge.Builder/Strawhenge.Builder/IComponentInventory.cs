namespace Strawhenge.Builder
{
    public interface IComponentInventory
    {
        void AddComponent(Component component);

        void AddComponent(Component component, int quantity);

        int Count(Component component);

        int CountTotal();

        void RemoveComponent(Component component);

        void RemoveComponent(Component component, int quantity);
    }
}