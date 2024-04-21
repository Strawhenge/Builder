using Strawhenge.Builder.Unity.Manager.UI;
using Strawhenge.Builder.Unity.UI;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class BuilderScript : MonoBehaviour
    {
        [SerializeField] BuilderManagerUIScript _managerUI;
        [SerializeField] BuildItemCompositionUIScript _itemCompositionUI;
        [SerializeField] MenuScript _menu;

        public BuilderManagerUI ManagerUI { private get; set; }

        public BuildItemCompositionUI ItemCompositionUI { private get; set; }

        public MenuView MenuView { private get; set; }

        void Start()
        {
            if (!ReferenceEquals(null, _managerUI))
                ManagerUI.Setup(_managerUI);

            if (!ReferenceEquals(null, _itemCompositionUI))
                ItemCompositionUI.Setup(_itemCompositionUI);

            if (!ReferenceEquals(null, _menu))
                MenuView.Setup(_menu);
        }

        void OnDestroy()
        {
            ManagerUI.Reset();
            ItemCompositionUI.Reset();
            MenuView.Reset();
        }
    }
}