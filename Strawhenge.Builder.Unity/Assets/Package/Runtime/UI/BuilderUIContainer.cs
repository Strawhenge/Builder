using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity.UI.Manager;
using Strawhenge.Builder.Unity.UI.Recipe;
using Strawhenge.Builder.Unity.UI.Scrap;

namespace Strawhenge.Builder.Unity.UI
{
    public class BuilderUIContainer
    {
        public BuilderUIContainer(
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