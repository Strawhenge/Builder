namespace Strawhenge.Builder.Unity.BuildItems
{
    public interface IControlsSettings
    {
        IBuildItemControlsSettings BuildItem { get; }

        IHorizontalSnapControlsSettings HorizontalSnap { get; }

        IVerticalSnapControlsSettings VerticalSnap { get; }
    }
}