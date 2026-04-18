using System;
using UnityEngine;
using UnityEngine.UI;

namespace Strawhenge.Builder.Unity.UI.Manager
{
    public class StandardBuilderManagerUIScript : BaseBuilderManagerUIScript, IBuilderManagerUI
    {
        [SerializeField] Canvas _canvas;
        [SerializeField] Button _menuButton;
        [SerializeField] Button _exitButton;

        public override IBuilderManagerUI BuilderManagerUI => this;

        public event Action ExitedBuilder;

        public event Action OpenedMenu;

        public void Show()
        {
            _canvas.enabled = true;
        }

        public void Hide()
        {
            _canvas.enabled = false;
        }

        void Awake()
        {
            _menuButton.onClick.AddListener(() => OpenedMenu?.Invoke());
            _exitButton.onClick.AddListener(() => ExitedBuilder?.Invoke());

            _canvas.enabled = false;
        }
    }
}