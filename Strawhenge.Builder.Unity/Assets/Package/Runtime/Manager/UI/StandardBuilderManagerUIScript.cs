using UnityEngine;
using UnityEngine.UI;

namespace Strawhenge.Builder.Unity.Manager.UI
{
    public class StandardBuilderManagerUIScript : BaseBuilderManagerUIScript
    {
        [SerializeField] Canvas _canvas;
        [SerializeField] Button _menuButton;
        [SerializeField] Button _exitButton;

        public override void Show()
        {
            _canvas.enabled = true;
        }

        public override void Hide()
        {
            _canvas.enabled = false;
        }

        void Awake()
        {
            _menuButton.onClick.AddListener(OpenMenu);
            _exitButton.onClick.AddListener(ExitBuilder);

            _canvas.enabled = false;
        }
    }
}