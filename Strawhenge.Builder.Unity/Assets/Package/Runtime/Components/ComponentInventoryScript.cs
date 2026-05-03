using Strawhenge.Common.Unity;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Components
{
    public class ComponentInventoryScript : MonoBehaviour
    {
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

            return new ComponentInventory(logger);
        }
    }
}