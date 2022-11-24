namespace Strawhenge.Builder.Unity.BuildItems
{
    public class NullBuildItem : IExistingBuildItem
    {
        public void Cancel()
        {
        }

        public void PlaceFinal()
        {
        }

        public IArrangeBuildItem Arrange() => new NullArrangeBuildItem();

        public void Scrap()
        {
        }
    }
}