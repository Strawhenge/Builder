using UnityEngine;
using UnityEngine.UI;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class RecipeUIComponentScript : MonoBehaviour
    {
        [SerializeField] Text _componentName;
        [SerializeField] Text _componentAmount;

        public void Set(string name, int amountRequired, int amountInInventory)
        {
            _componentName.text = name;
            _componentAmount.text = $"{amountInInventory} / {amountRequired}";
        }
    }
}