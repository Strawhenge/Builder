namespace Strawhenge.Builder.Unity
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
