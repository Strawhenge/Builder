using System;

namespace Strawhenge.Builder.Unity
{
    public interface IBuilderManagerUI
    {
        event Action ExitedBuilder;
        event Action OpenedMenu;

        void Show();

        void Hide();
    }
}