using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class ComponentInventoryScript : MonoBehaviour
    {
        public IComponentInventory Inventory { private get; set; }

        public void Add(ComponentsScript componentsScript)
        {
            foreach (var component in componentsScript.GetComponents())
            {
                Inventory.AddComponent(component.Component, component.Quantity);
            }
        }
    }
}
