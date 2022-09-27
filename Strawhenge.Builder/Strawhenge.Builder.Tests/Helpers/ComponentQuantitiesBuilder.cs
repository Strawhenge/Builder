using System.Collections.Generic;

namespace Strawhenge.Builder.Tests
{
    class ComponentQuantitiesBuilder
    {
        readonly List<ComponentQuantity> _componentQuantities = new List<ComponentQuantity>();

        public ComponentQuantitiesBuilder Add(ComponentQuantity componentQuantity)
        {
            _componentQuantities.Add(componentQuantity);
            return this;
        }

        public IEnumerable<ComponentQuantity> Build()
        {
            return _componentQuantities.ToArray();
        }
    }
}
