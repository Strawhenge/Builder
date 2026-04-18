using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity.Manager.UI;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Package.Runtime.UI
{
    public class UIContainerScript : MonoBehaviour
    {
        [SerializeField] BaseBuilderManagerUIScript _builderManagerUI;
        [SerializeField] BaseMenuScript _menu;

        internal IBuilderManagerUI BuilderManagerUI => _builderManagerUI.BuilderManagerUI;

        internal IMenuView Menu => _menu.MenuView;
    }
}