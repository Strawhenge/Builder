using System.Collections.Generic;
using System.Linq;

namespace Strawhenge.Builder
{
    public class ComponentInventory : IComponentInventory
    {
        readonly List<ComponentCounter> componentCounters = new List<ComponentCounter>();
        readonly ILogger logger;

        public ComponentInventory(ILogger logger)
        {
            this.logger = logger;
        }

        public bool InfiniteComponents { get; set; }

        public int CountTotal() => InfiniteComponents ? int.MaxValue : componentCounters.Sum(x => x.CurrentCount);

        public int Count(Component component)
        {
            if (InfiniteComponents)
                return int.MaxValue;

            var counter = componentCounters.SingleOrDefault(x => x.Component.Is(component));

            if (counter == null)
                return 0;

            return counter.CurrentCount;
        }

        public void AddComponent(Component component, int quantity)
        {
            if (quantity < 1)
            {
                logger.LogError(
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
                logger.LogError(
                    $"Cannot remove less than 1 component. [{nameof(quantity)}: {quantity}, {nameof(component)}: {component.Identifier}]");
                return;
            }

            if (InfiniteComponents)
                return;

            var componentCounter = GetOrCreateComponentCounter(component);
            componentCounter.Substract(quantity);
        }

        ComponentCounter GetOrCreateComponentCounter(Component component)
        {
            return componentCounters
                .SingleOrDefault(x => x.Component.Is(component)) ?? CreateComponentCounter();

            ComponentCounter CreateComponentCounter()
            {
                var componentQuantity = new ComponentCounter(component);
                componentCounters.Add(componentQuantity);
                return componentQuantity;
            }
        }
    }
}
