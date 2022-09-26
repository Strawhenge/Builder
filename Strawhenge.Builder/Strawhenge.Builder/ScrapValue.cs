using System.Collections.Generic;
using System.Linq;

namespace Strawhenge.Builder
{
    public class ScrapValue
    {
        readonly ComponentQuantity[] _components;

        public ScrapValue(IEnumerable<ComponentQuantity> components)
        {
            _components = components.ToArray();
        }

        public void AddComponentsTo(IComponentInventory inventory)
        {
            foreach (var component in _components)
                inventory.AddComponent(component);
        }
    }
}
