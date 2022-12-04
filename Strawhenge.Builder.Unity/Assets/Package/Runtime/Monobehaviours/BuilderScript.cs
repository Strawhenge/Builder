using Strawhenge.Builder.Unity.Manager.UI;
using Strawhenge.Builder.Unity.ScriptableObjects;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class BuilderScript : MonoBehaviour
    {
        [SerializeField] BlueprintScriptableObject[] _blueprints;

        public BlueprintRepository BlueprintRepository { private get; set; }

        public BuilderManagerUI ManagerUI { private get; set; }

        public MenuView MenuView { private get; set; }

        void Start()
        {
            BlueprintRepository.Add(_blueprints);
            ManagerUI.Setup(FindObjectOfType<BuilderManagerUIScript>(includeInactive: true));
            MenuView.Setup(FindObjectOfType<MenuScript>(includeInactive: true));
        }
    }
}