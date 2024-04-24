using System.Collections.Generic;
using System.Linq;
using Strawhenge.Common.Logging;

namespace Strawhenge.Builder
{
    public class ComponentInventory : IComponentInventory
    {
        readonly List<ComponentCounter> _componentCounters = new List<ComponentCounter>();
        readonly ILogger _logger;

        public ComponentInventory(ILogger logger)
        {
            _logger = logger;
        }

        public bool InfiniteComponents { get; set; }

        public int CountTotal() => InfiniteComponents ? int.MaxValue : _componentCounters.Sum(x => x.CurrentCount);

        public int Count(Component component)
        {
            if (InfiniteComponents)
                return int.MaxValue;

            var counter = _componentCounters.SingleOrDefault(x => x.Component.Is(component));

            if (counter == null)
                return 0;

            return counter.CurrentCount;
        }

        public IReadOnlyList<ComponentQuantity> GetComponents()
        {
            return _componentCounters
                .Select(x => x.Component.Quantity(x.CurrentCount))
                .ToArray();
        }

        public void AddComponent(Component component, int quantity)
        {
            if (quantity < 1)
            {
                _logger.LogError(
                    $"Cannot add less than 1 component. [{nameof(quantity)}: {quantity}, {nameof(component)}: {component.Identifier}]");
                return;
            }

            var componentCounter = GetOrCreateComponentCounter(component);
            componentCounter.Add(quantity);
        }

        public void RemoveComponent(Component component, int quantity)
        {
            if (quantity < 1)
            {
                _logger.LogError(
                    $"Cannot remove less than 1 component. [{nameof(quantity)}: {quantity}, {nameof(component)}: {component.Identifier}]");
                return;
            }

            if (InfiniteComponents)
                return;

            var componentCounter = GetOrCreateComponentCounter(component);
            componentCounter.Substract(quantity);
        }

        public void RemoveAllComponents()
        {
            _componentCounters.Clear();
        }

        ComponentCounter GetOrCreateComponentCounter(Component component)
        {
            return _componentCounters
                .SingleOrDefault(x => x.Component.Is(component)) ?? CreateComponentCounter();

            ComponentCounter CreateComponentCounter()
            {
                var componentQuantity = new ComponentCounter(component);
                _componentCounters.Add(componentQuantity);
                return componentQuantity;
            }
        }
    }
}