using Strawhenge.Builder.Unity.BuildItems.Arrange;

namespace Strawhenge.Builder.Unity.BuildItems.New
{
    interface IBuildItem
    {
        void Cancel();

        void PlaceFinal();

        IArrangeBuildItem Arrange();
    }
}