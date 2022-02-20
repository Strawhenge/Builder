using Strawhenge.Builder.Unity.Data;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class ComponentsScript : MonoBehaviour
    {
        [SerializeField] SerializableComponentQuantity[] components;

        public IEnumerable<ComponentQuantity> GetComponents()
        {
            foreach (var component in components.Where(x => x != null && x.Component != null))
            {
                yield return new ComponentQuantity(
                    component: new Component(component.Component.Identifier),
                    quantity: component.Quantity);
            }
        }
    }
}
