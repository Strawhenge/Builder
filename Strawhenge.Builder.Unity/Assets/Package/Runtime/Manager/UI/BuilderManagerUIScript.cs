using System;
using UnityEngine;
using UnityEngine.UI;

namespace Strawhenge.Builder.Unity.Manager.UI
{
    public class BuilderManagerUIScript : MonoBehaviour, IBuilderManagerUI
    {
        [SerializeField] Canvas _canvas;
        [SerializeField] Button _menuButton;
        [SerializeField] Button _exitButton;

        public event Action ExitBuilder;
        
        public event Action OpenMenu;

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
            _menuButton.onClick.AddListener(() => OpenMenu?.Invoke());
            _exitButton.onClick.AddListener(() => ExitBuilder?.Invoke());

            _canvas.enabled = false;
        }
    }
}