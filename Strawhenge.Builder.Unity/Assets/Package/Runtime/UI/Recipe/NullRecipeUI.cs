using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.UI.Recipe
{
    public class NullRecipeUI : IRecipeUI
    {
        public void Show(string recipeName, IEnumerable<RecipeRequirement> requirements)
        {
        }

        public void Hide()
        {
        }
    }
}