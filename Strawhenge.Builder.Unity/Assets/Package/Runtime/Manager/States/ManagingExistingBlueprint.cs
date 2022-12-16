using System;

namespace Strawhenge.Builder.Unity
{
    public partial class BuilderManager
    {
        class ManagingExistingBlueprint : IState
        {
            readonly ExistingBlueprintManager _manager;
            readonly Action _onEnded;

            Action _callback = () => { };

            public ManagingExistingBlueprint(ExistingBlueprintManager manager, Action onEnded)
            {
                _manager = manager;
                _onEnded = onEnded;
            }

            public ExistingBlueprint Blueprint { private get; set; }

            public void Begin()
            {
                _callback = _onEnded;
                _manager.Set(Blueprint, () => _callback());
            }

            public void End()
            {
                _callback = () => { };
                _manager.Unset();
            }
        }
    }
}