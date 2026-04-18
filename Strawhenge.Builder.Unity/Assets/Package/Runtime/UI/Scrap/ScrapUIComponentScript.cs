using UnityEngine;
using UnityEngine.UI;

namespace Strawhenge.Builder.Unity.UI
{
    public class ScrapUIComponentScript : MonoBehaviour
    {
        [SerializeField] Text _componentName;
        [SerializeField] Text _componentAmount;

        public void Set(string name, int amount, int amountInInventory)
        {
            _componentName.text = name;
            _componentAmount.text = $"{amount} ({amountInInventory})";
        }
    }
}