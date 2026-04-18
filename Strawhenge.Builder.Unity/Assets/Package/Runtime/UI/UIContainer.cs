using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity.UI;

namespace Strawhenge.Builder.Unity.Package.Runtime.UI
{
    public class UIContainer
    {
        public UIContainer(
            IBuilderManagerUI builderManagerUI,
            IMenuView menuView,
            IRecipeUI recipeUI,
            IScrapUI scrapUI)
        {
            BuilderManagerUI = builderManagerUI;
            MenuView = menuView;
            RecipeUI = recipeUI;
            ScrapUI = scrapUI;
        }

        public IBuilderManagerUI BuilderManagerUI { get; }

        public IMenuView MenuView { get; }

        public IRecipeUI RecipeUI { get; }

        public IScrapUI ScrapUI { get; }
    }
}