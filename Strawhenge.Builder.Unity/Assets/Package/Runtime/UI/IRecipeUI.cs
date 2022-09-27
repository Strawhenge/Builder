using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.UI
{
    public interface IRecipeUI
    {
        void Show(string recipeName, IEnumerable<RecipeRequirement> requirements);

        void Hide();
    }
}