using System;
using UnityEngine;
using UnityEngine.UI;

namespace Strawhenge.Builder.Unity.Manager.UI
{
    public class BuilderManagerUIScript : MonoBehaviour
    {
        [SerializeField] Button _menuButton;
        [SerializeField] Button _exitButton;

        public Action OpenMenu { private get; set; }

        public Action Exit { private get; set; }

        public void Show()
        {
            // SetActive must be called twice due to a Unity bug
            gameObject.SetActive(true);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        void Awake()
        {
            _menuButton.onClick.AddListener(() => OpenMenu?.Invoke());
            _exitButton.onClick.AddListener(() => Exit?.Invoke());

            gameObject.SetActive(false);
        }
    }
}