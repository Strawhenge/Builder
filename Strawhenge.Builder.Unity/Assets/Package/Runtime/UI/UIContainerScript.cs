using Strawhenge.Builder.Unity.Manager.UI;
using Strawhenge.Builder.Unity.UI;
using Strawhenge.Common.Unity.Helpers;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Package.Runtime.UI
{
    public class UIContainerScript : MonoBehaviour
    {
        [SerializeField] BaseBuilderManagerUIScript _builderManagerUI;
        [SerializeField] BaseMenuScript _menu;
        [SerializeField] BaseRecipeUIScript _recipeUI;
        [SerializeField] BaseScrapUIScript _scrapUI;

        UIContainer _container;

        internal UIContainer Container => _container ??= Create();

        UIContainer Create()
        {
            ComponentRefHelper.EnsureSceneComponent(ref _builderManagerUI, nameof(_builderManagerUI), this);
            ComponentRefHelper.EnsureSceneComponent(ref _menu, nameof(_menu), this);
            ComponentRefHelper.EnsureSceneComponent(ref _recipeUI, nameof(_recipeUI), this);
            ComponentRefHelper.EnsureSceneComponent(ref _scrapUI, nameof(_scrapUI), this);

            return new UIContainer(
                _builderManagerUI.BuilderManagerUI,
                _menu.MenuView,
                _recipeUI.RecipeUI,
                _scrapUI.ScrapUI);
        }
    }
}