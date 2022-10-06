using System;

namespace Strawhenge.Builder
{
    public class ScrapAddition
    {
        public ScrapAddition(Component component, int additionalQuantity, int quantityInInventory)
        {
            Component = component ?? throw new ArgumentNullException(nameof(component));

            if (additionalQuantity < 1)
                throw new ArgumentException("Scrap quantity cannot be less than 1.", nameof(additionalQuantity));

            AdditionalQuantity = additionalQuantity;

            if (quantityInInventory < 0)
                throw new ArgumentException("Inventory quantity cannot be less than 0.", nameof(quantityInInventory));

            QuantityInInventory = quantityInInventory;
        }

        public Component Component { get; }

        public int AdditionalQuantity { get; }

        public int QuantityInInventory { get; set; }
    }
}
