using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class RecipeUIScript : MonoBehaviour
    {
        [SerializeField] Text _titleText;
        [SerializeField] Transform _componentsParent;
        [SerializeField] RecipeUIComponentScript _componentPrefab;

        readonly List<GameObject> _currentComponents = new List<GameObject>();

        public void SetTitle(string title) => _titleText.text = title;

        public void ClearComponents()
        {
            foreach (var component in _currentComponents.ToArray())
            {
                _currentComponents.Remove(component);
                Destroy(component);
            }
        }

        public void AddComponent(string name, int amountRequired, int amountInInventory)
        {
            var component = Instantiate(_componentPrefab, parent: _componentsParent);
            component.Set(name, amountRequired, amountInInventory);

            _currentComponents.Add(component.gameObject);
        }
    }
}