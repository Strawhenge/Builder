namespace Strawhenge.Builder.Unity
{
    public partial class BuilderManager
    {
        class ManagingNewBlueprint : IState
        {
            readonly BlueprintManager _blueprintManager;

            public ManagingNewBlueprint(BlueprintManager blueprintManager)
            {
                _blueprintManager = blueprintManager;
            }

            public Blueprint Blueprint { private get; set; }

            public void Begin()
            {
                _blueprintManager.Set(Blueprint);
            }

            public void End()
            {
                _blueprintManager.Unset();
            }
        }
    }
}
