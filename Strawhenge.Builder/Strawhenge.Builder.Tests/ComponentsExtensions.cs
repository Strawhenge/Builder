namespace Strawhenge.Builder.Tests
{
    static class ComponentsExtensions
    {
        public static ComponentQuantity One(this Component component) =>
            new ComponentQuantity(component, 1);

        public static ComponentQuantity Five(this Component component) =>
           new ComponentQuantity(component, 5);
    }
}
