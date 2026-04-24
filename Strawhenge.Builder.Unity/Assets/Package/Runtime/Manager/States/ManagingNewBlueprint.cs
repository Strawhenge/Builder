using Strawhenge.Builder.Unity.BuildItems.New;
using System;

namespace Strawhenge.Builder.Unity.Manager
{
    public partial class BuilderManager
    {
        class ManagingNewBlueprint : IState
        {
            readonly NewBuildableItemManager _newBuildableItemManager;
            readonly Action _onEnded;

            Action _callback = () => { };

            public ManagingNewBlueprint(NewBuildableItemManager newBuildableItemManager, Action onEnded)
            {
                _newBuildableItemManager = newBuildableItemManager;
                _onEnded = onEnded;
            }

            public NewBuildableItem NewBuildableItem { private get; set; }

            public void Begin()
            {
                _callback = _onEnded;
                _newBuildableItemManager.Set(NewBuildableItem, () => _callback());
            }

            public void End()
            {
                _callback = () => { };
                _newBuildableItemManager.Unset();
            }
        }
    }
}