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

        public IBuildItemPreview Preview() => new NullBuildItemPreview();
    }
}