using System;

namespace Strawhenge.Builder.Unity
{
    public partial class BuilderManager
    {
        class ManagingNewBlueprint : IState
        {
            readonly BlueprintManager _blueprintManager;
            readonly Action _onEnded;

            Action _callback = () => { };

            public ManagingNewBlueprint(BlueprintManager blueprintManager, Action onEnded)
            {
                _blueprintManager = blueprintManager;
                _onEnded = onEnded;
            }

            public Blueprint Blueprint { private get; set; }

            public void Begin()
            {
                _callback = _onEnded;
                _blueprintManager.Set(Blueprint, () => _callback());
            }

            public void End()
            {
                _callback = () => { };
                _blueprintManager.Unset();
            }
        }
    }
}