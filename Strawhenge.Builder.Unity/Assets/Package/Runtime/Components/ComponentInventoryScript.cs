using Strawhenge.Common.Unity;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Components
{
    public class ComponentInventoryScript : MonoBehaviour
    {
        [SerializeField] SerializableComponentQuantity[] _components;
        [SerializeField] LoggerScript _logger;

        ComponentInventory _inventory;

        public ComponentInventory Inventory => _inventory ??= Create();

        void Awake()
        {
            _inventory ??= Create();
        }

        ComponentInventory Create()
        {
            var logger = _logger != null
                ? _logger.Logger
                : new UnityLogger(gameObject);

            var inventory = new ComponentInventory(logger);

            foreach (var component in _components)
                inventory.AddComponent(
                    new Component(component.Component.Identifier), component.Quantity);

            return inventory;
        }
    }
}