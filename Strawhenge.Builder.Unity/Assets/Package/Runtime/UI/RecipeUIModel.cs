using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.UI
{
    public class RecipeUIModel
    {
        public string RecipeTitle { get; set; }

        public IEnumerable<RecipeRequirementUIModel> Requirements { get; set; }
    }
}