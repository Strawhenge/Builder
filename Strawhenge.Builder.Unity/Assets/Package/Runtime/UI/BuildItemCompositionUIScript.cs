using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Strawhenge.Builder.Unity.UI
{
    public class BuildItemCompositionUIScript : MonoBehaviour
    {
        [SerializeField] Text _title;
        [SerializeField] Text _subtitle;
        [SerializeField] string _recipeSubtitleText;
        [SerializeField] string _scrapSubtitleText;
        [SerializeField] Transform _componentsParent;
        [SerializeField] RecipeUIComponentScript _recipeComponentPrefab;
        [SerializeField] ScrapUIComponentScript _scrapComponentPrefab;

        readonly List<GameObject> _currentComponents = new List<GameObject>();

        public void SetTitle(string title) => _title.text = title;

        public void SetRecipeSubtitle() => _subtitle.text = _recipeSubtitleText;

        public void SetScrapSubtitle() => _subtitle.text = _scrapSubtitleText;

        public void ClearComponents()
        {
            foreach (var component in _currentComponents.ToArray())
            {
                _currentComponents.Remove(component);
                Destroy(component);
            }
        }

        public void AddRecipeComponent(string name, int amountRequired, int amountInInventory)
        {
            var component = Instantiate(_recipeComponentPrefab, parent: _componentsParent);
            component.Set(name, amountRequired, amountInInventory);

            _currentComponents.Add(component.gameObject);
        }

        public void AddScrapComponent(string name, int amount, int amountInInventory)
        {
            var component = Instantiate(_scrapComponentPrefab, parent: _componentsParent);
            component.Set(name, amount, amountInInventory);

            _currentComponents.Add(component.gameObject);
        }
    }
}