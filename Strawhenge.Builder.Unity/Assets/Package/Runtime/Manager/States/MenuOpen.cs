using Strawhenge.Builder.Unity.ScriptableObjects;
using System;

namespace Strawhenge.Builder.Unity
{
    public partial class BuilderManager
    {
        class MenuOpen : IState
        {
            readonly IBlueprintScriptableObjectMenu _menu;
            readonly Action<BlueprintScriptableObject> _onBlueprintSelected;
            readonly Action _onMenuClosed;

            public MenuOpen(
                IBlueprintScriptableObjectMenu menu,
                Action<BlueprintScriptableObject> onBlueprintSelected,
                Action onMenuClosed)
            {
                _menu = menu;
                _onBlueprintSelected = onBlueprintSelected;
                _onMenuClosed = onMenuClosed;
            }

            public void Begin()
            {
                _menu.Open();
                _menu.Select += _onBlueprintSelected;
                _menu.Exit += _onMenuClosed;
            }

            public void End()
            {
                _menu.Select -= _onBlueprintSelected;
                _menu.Exit -= _onMenuClosed;
                _menu.Close();
            }
        }
    }
}
