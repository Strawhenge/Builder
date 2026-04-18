using Strawhenge.Builder.Unity.BuildItems.Arrange;
using Strawhenge.Builder.Unity.BuildItems.Existing;

namespace Strawhenge.Builder.Unity.BuildItems
{
    class NullBuildItem : IExistingBuildItem
    {
        public static IExistingBuildItem Instance { get; } = new NullBuildItem();

        NullBuildItem()
        {
        }

        public void Cancel()
        {
        }

        public void PlaceFinal()
        {
        }

        public IArrangeBuildItem Arrange() => NullArrangeBuildItem.Instance;

        public void Scrap()
        {
        }
    }
}