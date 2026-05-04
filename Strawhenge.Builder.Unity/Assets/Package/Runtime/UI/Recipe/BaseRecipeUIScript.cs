using UnityEngine;

namespace Strawhenge.Builder.Unity.UI.Recipe
{
    public abstract class BaseRecipeUIScript : MonoBehaviour
    {
        public abstract IRecipeUI RecipeUI { get; }
    }
}