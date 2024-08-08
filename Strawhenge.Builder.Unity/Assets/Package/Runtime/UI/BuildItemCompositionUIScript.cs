using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Strawhenge.Builder.Unity.UI
{
    public class BuildItemCompositionUIScript : MonoBehaviour
    {
        [SerializeField] Canvas _canvas;
        [SerializeField] Text _title;
        [SerializeField] Text _subtitle;
        [SerializeField] string _recipeSubtitleText;
        [SerializeField] string _scrapSubtitleText;
        [SerializeField] Transform _componentsParent;
        [SerializeField] RecipeUIComponentScript _recipeComponentPrefab;
        [SerializeField] ScrapUIComponentScript _scrapComponentPrefab;

        readonly List<GameObject> _currentComponents = new List<GameObject>();

        public void ShowRecipe(string title, IEnumerable<RecipeRequirement> requirements)
        {
            ClearComponents();
            SetTitle(title);
            SetRecipeSubtitle();

            foreach (var requirement in requirements)
            {
                AddRecipeComponent(
                    requirement.Component.Identifier,
                    requirement.QuantityRequired,
                    requirement.QuantityInInventory);
            }

            _canvas.enabled = true;
        }

        public void ShowScrap(string title, IEnumerable<ScrapAddition> additions)
        {
            ClearComponents();
            SetTitle(title);
            SetScrapSubtitle();

            foreach (var addition in additions)
            {
                AddScrapComponent(
                    addition.Component.Identifier,
                    addition.AdditionalQuantity,
                    addition.QuantityInInventory);
            }

            _canvas.enabled = true;
        }

        public void Hide()
        {
            _canvas.enabled = false;
        }

        void SetTitle(string title) => _title.text = title;

        void SetRecipeSubtitle() => _subtitle.text = _recipeSubtitleText;

        void SetScrapSubtitle() => _subtitle.text = _scrapSubtitleText;

        void ClearComponents()
        {
            foreach (var component in _currentComponents.ToArray())
            {
                _currentComponents.Remove(component);
                Destroy(component);
            }
        }

        void AddRecipeComponent(string name, int amountRequired, int amountInInventory)
        {
            var component = Instantiate(_recipeComponentPrefab, parent: _componentsParent);
            component.Set(name, amountRequired, amountInInventory);

            _currentComponents.Add(component.gameObject);
        }

        void AddScrapComponent(string name, int amount, int amountInInventory)
        {
            var component = Instantiate(_scrapComponentPrefab, parent: _componentsParent);
            component.Set(name, amount, amountInInventory);

            _currentComponents.Add(component.gameObject);
        }

        void Awake()
        {
            _canvas.enabled = false;
        }
    }
}