using UnityEngine;

namespace Strawhenge.Builder.Unity.UI.Recipe
{
    public class StandardRecipeUIScript : BaseRecipeUIScript
    {
        [SerializeField] BuildItemCompositionUIScript _buildItemCompositionUI;

        public override IRecipeUI RecipeUI => _buildItemCompositionUI;
    }
}