namespace Strawhenge.Builder.Unity.BuildItems
{
    public interface IBuildItem
    {
        void Cancel();

        void PlaceFinal();

        IArrangeBuildItem Preview();
    }
}