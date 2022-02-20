namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    public interface IBuilderSnapLayerAccessor
    {
        int VerticalLayer { get; }

        int HorizontalLayer { get; }
    }
}