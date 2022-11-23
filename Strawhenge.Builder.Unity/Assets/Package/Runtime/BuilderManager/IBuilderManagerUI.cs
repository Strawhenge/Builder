using System;

namespace Strawhenge.Builder.Unity
{
    public interface IBuilderManagerUI
    {
        event Action ExitBuilder;
        event Action OpenMenu;

        void Enable();

        void Disable();
    }
}