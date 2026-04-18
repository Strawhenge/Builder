using Strawhenge.Builder.Unity.BuildItems.Arrange;

namespace Strawhenge.Builder.Unity.BuildItems.New
{
    public interface IBuildItem
    {
        void Cancel();

        void PlaceFinal();

        IArrangeBuildItem Arrange();
    }
}