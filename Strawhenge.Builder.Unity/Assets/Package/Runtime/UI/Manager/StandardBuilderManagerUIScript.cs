using System;
using UnityEngine;
using UnityEngine.UI;

namespace Strawhenge.Builder.Unity.UI.Manager
{
    public class StandardBuilderManagerUIScript : BaseBuilderManagerUIScript, IBuilderManagerUI
    {
        [SerializeField] RectTransform _containerPanel;
        [SerializeField] Button _menuButton;
        [SerializeField] Button _exitButton;

        public override IBuilderManagerUI BuilderManagerUI => this;

        public event Action ExitedBuilder;

        public event Action OpenedMenu;

        public void Show()
        {
            _containerPanel.gameObject.SetActive(true);
        }

        public void Hide()
        {
            _containerPanel.gameObject.SetActive(false);
        }

        void Awake()
        {
            _menuButton.onClick.AddListener(() => OpenedMenu?.Invoke());
            _exitButton.onClick.AddListener(() => ExitedBuilder?.Invoke());

            _containerPanel.gameObject.SetActive(false);
        }
    }
}