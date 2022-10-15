﻿using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class ComponentInventoryScript : MonoBehaviour
    {
        [SerializeField] bool _infiniteComponents;

        public IComponentInventory Inventory { private get; set; }

        public void Add(ComponentsScript componentsScript)
        {
            foreach (var component in componentsScript.GetComponents())
            {
                Inventory.AddComponent(component.Component, component.Quantity);
            }
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
        }
    }
}