using Strawhenge.Builder.Unity.Manager.UI;
using Strawhenge.Builder.Unity.UI;
using UnityEngine;
using UnityEngine.Events;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class BuilderScript : MonoBehaviour
    {
        [SerializeField] BuilderManagerUIScript _managerUI;
        [SerializeField] BuildItemCompositionUIScript _itemCompositionUI;
        [SerializeField] MenuScript _menu;
        [SerializeField] UnityEvent _turningOn;
        [SerializeField] UnityEvent _turnedOff;

        public BuilderManager BuilderManager { private get; set; }

        public BuilderManagerUI ManagerUI { private get; set; }

        public BuildItemCompositionUI ItemCompositionUI { private get; set; }

        public MenuView MenuView { private get; set; }

        [ContextMenu(nameof(On))]
        public void On() => BuilderManager.On();

        [ContextMenu(nameof(Off))]
        public void Off() => BuilderManager.Off();

        void Start()
        {
            if (!ReferenceEquals(null, _managerUI))
                ManagerUI.Setup(_managerUI);

            if (!ReferenceEquals(null, _itemCompositionUI))
                ItemCompositionUI.Setup(_itemCompositionUI);

            if (!ReferenceEquals(null, _menu))
                MenuView.Setup(_menu);

            BuilderManager.TurningOn += OnBuilderTuringOn;
            BuilderManager.TurnedOff += OnBuilderTurningOff;
        }

        void OnDestroy()
        {
            ManagerUI.Reset();
            ItemCompositionUI.Reset();
            MenuView.Reset();

            BuilderManager.TurningOn -= OnBuilderTuringOn;
            BuilderManager.TurnedOff -= OnBuilderTurningOff;
        }

        void OnBuilderTuringOn() => _turningOn.Invoke();

        void OnBuilderTurningOff() => _turnedOff.Invoke();
    }
}