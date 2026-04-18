using System;

namespace Strawhenge.Builder.Unity.UI.Manager
{
    public interface IBuilderManagerUI
    {
        event Action ExitedBuilder;
        event Action OpenedMenu;

        void Show();

        void Hide();
    }
}