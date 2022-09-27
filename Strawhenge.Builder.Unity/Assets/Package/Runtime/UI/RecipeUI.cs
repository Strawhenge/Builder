using Strawhenge.Builder.Unity.Monobehaviours;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.UI
{
    public class RecipeUI : IRecipeUI
    {
        readonly RecipeUIScript _script;

        public RecipeUI(ILogger logger)
        {
            _script = Object.FindObjectOfType<RecipeUIScript>(includeInactive: true);

            if (_script == null)
                logger.LogError($"Cannot find {nameof(RecipeUIScript)}.");

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
            _script.ClearComponents();

            foreach (var requirement in requirements)
                _script.AddComponent(requirement.Component.Identifier, requirement.QuantityRequired, requirement.QuantityInInventory);

            _script.gameObject.SetActive(true);
        }
    }
}