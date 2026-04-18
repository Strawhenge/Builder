using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity.Manager.UI;
using Strawhenge.Builder.Unity.UI;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Package.Runtime.UI
{
    public class UIContainerScript : MonoBehaviour
    {
        [SerializeField] BaseBuilderManagerUIScript _builderManagerUI;
        [SerializeField] BaseMenuScript _menu;
        [SerializeField] BaseRecipeUIScript _recipeUI;
        [SerializeField] BaseScrapUIScript _scrapUI;

        internal IBuilderManagerUI BuilderManagerUI => _builderManagerUI.BuilderManagerUI;

        internal IMenuView Menu => _menu.MenuView;

        internal IRecipeUI RecipeUI => _recipeUI.RecipeUI;

        internal IScrapUI ScrapUI => _scrapUI.ScrapUI;
    }
}