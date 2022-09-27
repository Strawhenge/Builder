using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.UI
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