using System;

namespace Strawhenge.Builder.Unity
{
    public partial class BuilderManager
    {
        class ManagingExistingBlueprint : IState
        {
            readonly ExistingBlueprintManager _manager;
            readonly Action _onEnded;

            public ManagingExistingBlueprint(ExistingBlueprintManager manager, Action onEnded)
            {
                _manager = manager;
                _onEnded = onEnded;
            }

            public ExistingBlueprint Blueprint { private get; set; }

            public void Begin()
            {
                _manager.Set(Blueprint, callback: _onEnded);
            }

            public void End()
            {
                _manager.Unset();
            }
        }
    }
}
