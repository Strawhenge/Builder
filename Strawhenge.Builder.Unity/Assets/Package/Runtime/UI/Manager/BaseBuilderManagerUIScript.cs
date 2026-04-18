using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Manager.UI
{
    public abstract class BaseBuilderManagerUIScript : MonoBehaviour, IBuilderManagerUI
    {
        public event Action ExitedBuilder;
        public event Action OpenedMenu;

        public abstract void Show();

        public abstract void Hide();

        protected void ExitBuilder() => ExitedBuilder?.Invoke();

        protected void OpenMenu() => OpenedMenu?.Invoke();
    }
}