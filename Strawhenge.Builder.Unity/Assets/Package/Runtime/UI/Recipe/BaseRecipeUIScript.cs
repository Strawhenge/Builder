using UnityEngine;

namespace Strawhenge.Builder.Unity.UI
{
    public abstract class BaseRecipeUIScript : MonoBehaviour
    {
        public abstract IRecipeUI RecipeUI { get; }
    }
}