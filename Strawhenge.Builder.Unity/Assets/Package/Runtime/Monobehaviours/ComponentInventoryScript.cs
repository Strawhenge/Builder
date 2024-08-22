using Strawhenge.Builder.Unity.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class ComponentInventoryScript : MonoBehaviour
    {
        [SerializeField] SerializableComponentQuantity[] _components;
        [SerializeField] bool _infiniteComponents;

        public IComponentInventory Inventory { private get; set; }

        public void Add(ComponentsScript componentsScript) =>
            Add(componentsScript.GetComponents());

        public void Add(IEnumerable<ComponentQuantity> components)
        {
            foreach (var component in components)
                Inventory.AddComponent(component.Component, component.Quantity);
        }

        [ContextMenu("Infinite Components On")]
        public void InfiniteComponentsOn()
        {
            _infiniteComponents = true;

            if (Inventory != null)
                Inventory.InfiniteComponents = true;
        }

        [ContextMenu("Infinite Components Off")]
        public void InfiniteComponentsOff()
        {
            _infiniteComponents = false;

            if (Inventory != null)
                Inventory.InfiniteComponents = false;
        }

        void Start()
        {
            Inventory.InfiniteComponents = _infiniteComponents;

            foreach (var component in _components)
                Inventory.AddComponent(
                    new Component(component.Component.Identifier), component.Quantity);
        }
    }
}