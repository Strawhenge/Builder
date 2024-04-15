using System;

namespace Strawhenge.Builder
{
    public class ComponentQuantity
    {
        public ComponentQuantity(Component component, int quantity)
        {
            Component = component ?? throw new ArgumentNullException(nameof(component));
            Quantity = quantity;
        }

        public Component Component { get; }

        public int Quantity { get; }
    }
}
