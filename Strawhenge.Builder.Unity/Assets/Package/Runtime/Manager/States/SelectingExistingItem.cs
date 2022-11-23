using Strawhenge.Builder.Unity.Monobehaviours;
using System;

namespace Strawhenge.Builder.Unity
{
    public partial class BuilderManager
    {
        class SelectingExistingItem : IState
        {
            readonly IBuilderManagerUI _builderManagerUI;
            readonly IBuildItemScriptSelector _buildItemScriptSelector;
            readonly Action<BuildItemScript> _onSelectedItem;
            readonly Action _onOpenMenu;
            readonly Action _onExitBuilder;

            public SelectingExistingItem(
                IBuilderManagerUI builderManagerUI,
                IBuildItemScriptSelector buildItemScriptSelector,
                Action<BuildItemScript> onSelectedItem,
                Action onOpenMenu,
                Action onExitBuilder)
            {
                _builderManagerUI = builderManagerUI;
                _buildItemScriptSelector = buildItemScriptSelector;
                _onSelectedItem = onSelectedItem;
                _onOpenMenu = onOpenMenu;
                _onExitBuilder = onExitBuilder;
            }

            public void Begin()
            {
                _builderManagerUI.Enable();
                _buildItemScriptSelector.Enable();

                _builderManagerUI.OpenMenu += _onOpenMenu;
                _builderManagerUI.ExitBuilder += _onExitBuilder;
                _buildItemScriptSelector.Select += _onSelectedItem;
            }

            public void End()
            {
                _buildItemScriptSelector.Select -= _onSelectedItem;
                _builderManagerUI.OpenMenu -= _onOpenMenu;
                _builderManagerUI.ExitBuilder -= _onExitBuilder;

                _buildItemScriptSelector.Disable();
                _builderManagerUI.Disable();
            }
        }
    }
}
