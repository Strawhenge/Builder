using System;

namespace Strawhenge.Builder.Unity
{
    public partial class BuilderManager
    {
        class ManagingExistingBlueprint : IState
        {
            readonly ExistingBuildableItemManager _manager;
            readonly Action _onEnded;

            Action _callback = () => { };

            public ManagingExistingBlueprint(ExistingBuildableItemManager manager, Action onEnded)
            {
                _manager = manager;
                _onEnded = onEnded;
            }

            public ExistingBuildableItem BuildableItem { private get; set; }

            public void Begin()
            {
                _callback = _onEnded;
                _manager.Set(BuildableItem, () => _callback());
            }

            public void End()
            {
                _callback = () => { };
                _manager.Unset();
            }
        }
    }
}