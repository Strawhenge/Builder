using System;

namespace Strawhenge.Builder.Unity
{
    public partial class BuilderManager
    {
        class ManagingNewBlueprint : IState
        {
            readonly BlueprintManager _blueprintManager;
            readonly Action _onEnded;

            public ManagingNewBlueprint(BlueprintManager blueprintManager, Action onEnded)
            {
                _blueprintManager = blueprintManager;
                _onEnded = onEnded;
            }

            public Blueprint Blueprint { private get; set; }

            public void Begin()
            {
                _blueprintManager.Set(Blueprint, _onEnded);
            }

            public void End()
            {
                _blueprintManager.Unset();
            }
        }
    }
}
