using Strawhenge.Builder.Unity.ScriptableObjects;
using System;

namespace Strawhenge.Builder.Unity
{
    public partial class BuilderManager
    {
        class MenuOpen : IState
        {
            readonly BlueprintMenu _menu;
            readonly Action<IBlueprint> _onBlueprintSelected;
            readonly Action _onMenuClosed;

            public MenuOpen(
                BlueprintMenu menu,
                Action<IBlueprint> onBlueprintSelected,
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
