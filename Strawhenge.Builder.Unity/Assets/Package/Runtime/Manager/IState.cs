namespace Strawhenge.Builder.Unity.Manager
{
    public partial class BuilderManager
    {
        interface IState
        {
            void Begin();

            void End();
        }
    }
}
