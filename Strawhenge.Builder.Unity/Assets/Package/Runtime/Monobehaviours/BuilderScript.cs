using Strawhenge.Builder.Unity.Manager.UI;
using Strawhenge.Builder.Unity.ScriptableObjects;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class BuilderScript : MonoBehaviour
    {
        [SerializeField] BlueprintScriptableObject[] _blueprints;
        [SerializeField] BuilderManagerUIScript _managerUI;
        [SerializeField] MenuScript _menu;

        public BlueprintRepository BlueprintRepository { private get; set; }

        public BuilderManagerUI ManagerUI { private get; set; }

        public MenuView MenuView { private get; set; }

        void Start()
        {
            BlueprintRepository.Add(_blueprints);

            if (!ReferenceEquals(null, _managerUI))
                ManagerUI.Setup(_managerUI);

            if (!ReferenceEquals(null, _menu))
                MenuView.Setup(_menu);
        }
    }
}