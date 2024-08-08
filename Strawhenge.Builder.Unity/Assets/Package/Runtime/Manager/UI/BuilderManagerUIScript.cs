using System;
using UnityEngine;
using UnityEngine.UI;

namespace Strawhenge.Builder.Unity.Manager.UI
{
    public class BuilderManagerUIScript : MonoBehaviour
    {
        [SerializeField] Canvas _canvas;
        [SerializeField] Button _menuButton;
        [SerializeField] Button _exitButton;

        public Action OpenMenu { private get; set; }

        public Action Exit { private get; set; }

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
            _exitButton.onClick.AddListener(() => Exit?.Invoke());

            _canvas.enabled = false;
        }
    }
}