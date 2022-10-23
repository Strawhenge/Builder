namespace Strawhenge.Builder.Unity.BuildItems
{
    public class NullBuildItem : IBuildItem
    {
        public void Cancel()
        {
        }

        public void PlaceFinal()
        {
        }

        public IArrangeBuildItem Preview() => new NullArrangeBuildItem();
    }
}