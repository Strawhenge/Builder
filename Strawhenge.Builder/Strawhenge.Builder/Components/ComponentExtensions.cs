namespace Strawhenge.Builder
{
    public static class ComponentExtensions
    {
        public static ComponentQuantity Quantity(this Component component, int quantity) =>
            new ComponentQuantity(component, quantity);
    }
}
