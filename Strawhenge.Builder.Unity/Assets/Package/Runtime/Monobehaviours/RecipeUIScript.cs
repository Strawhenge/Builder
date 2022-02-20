using Strawhenge.Builder.Unity.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class RecipeUIScript : MonoBehaviour, IRecipeUI
    {
        public Text TitleText;
        public Text ComponentsText;

        private void Start()
        {
            Hide();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show(RecipeUIModel recipe)
        {
            TitleText.text = recipe.RecipeTitle;
            ComponentsText.text = BuildRequirementsString(recipe.Requirements);

            gameObject.SetActive(true);
        }

        private string BuildRequirementsString(IEnumerable<RecipeRequirementUIModel> requirements)
        {
            return string.Join(Environment.NewLine, requirements.Select(Stringify));

            string Stringify(RecipeRequirementUIModel requirement)
            {
                return $"{requirement.ComponentName} - {requirement.QuantityInInventory}/{requirement.QuantityRequired}";
            }
        }
    }
}