using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.UI
{
    public class BuildItemCompositionUI : IRecipeUI, IScrapUI
    {
        readonly BuildItemCompositionUIScript _script;

        public BuildItemCompositionUI(ILogger logger)
        {
            _script = Object.FindObjectOfType<BuildItemCompositionUIScript>(includeInactive: true);

            if (_script == null)
                logger.LogError($"Cannot find {nameof(BuildItemCompositionUIScript)}.");

            Hide();
        }

        public void Hide()
        {
            if (_script == null)
                return;

            _script.gameObject.SetActive(false);
        }

        public void Show(string recipeName, IEnumerable<RecipeRequirement> requirements)
        {
            if (_script == null)
                return;

            _script.SetTitle(recipeName);
            _script.SetRecipeSubtitle();
            _script.ClearComponents();

            foreach (var requirement in requirements)
                _script.AddRecipeComponent(requirement.Component.Identifier, requirement.QuantityRequired, requirement.QuantityInInventory);

            _script.gameObject.SetActive(true);
        }

        public void Show(string scrapName, IEnumerable<ScrapAddition> additions)
        {
            if (_script == null)
                return;

            _script.SetTitle(scrapName);
            _script.SetScrapSubtitle();
            _script.ClearComponents();

            foreach (var addition in additions)
                _script.AddScrapComponent(addition.Component.Identifier, addition.AdditionalQuantity, addition.QuantityInInventory);

            _script.gameObject.SetActive(true);
        }
    }
}