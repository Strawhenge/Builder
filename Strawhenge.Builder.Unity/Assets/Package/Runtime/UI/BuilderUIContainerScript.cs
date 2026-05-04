using Strawhenge.Builder.Unity.UI.Manager;
using Strawhenge.Builder.Unity.UI.Menu;
using Strawhenge.Builder.Unity.UI.Recipe;
using Strawhenge.Builder.Unity.UI.Scrap;
using Strawhenge.Common.Unity.Helpers;
using UnityEngine;

namespace Strawhenge.Builder.Unity.UI
{
    public class BuilderUIContainerScript : MonoBehaviour
    {
        [SerializeField] BaseBuilderManagerUIScript _builderManagerUI;
        [SerializeField] BaseMenuScript _menu;
        [SerializeField] BaseRecipeUIScript _recipeUI;
        [SerializeField] BaseScrapUIScript _scrapUI;

        BuilderUIContainer _container;

        internal BuilderUIContainer Container => _container ??= Create();

        BuilderUIContainer Create()
        {
            ComponentRefHelper.EnsureSceneComponent(ref _builderManagerUI, nameof(_builderManagerUI), this);
            ComponentRefHelper.EnsureSceneComponent(ref _menu, nameof(_menu), this);
            ComponentRefHelper.EnsureSceneComponent(ref _recipeUI, nameof(_recipeUI), this);
            ComponentRefHelper.EnsureSceneComponent(ref _scrapUI, nameof(_scrapUI), this);

            return new BuilderUIContainer(
                _builderManagerUI.BuilderManagerUI,
                _menu.MenuView,
                _recipeUI.RecipeUI,
                _scrapUI.ScrapUI);
        }
    }
}