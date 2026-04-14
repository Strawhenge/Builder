namespace Strawhenge.Builder.Unity.BuildItems
{
    public sealed class DefaultControlsSettings : IControlsSettings
    {
        public static DefaultControlsSettings Instance { get; } = new DefaultControlsSettings();

        DefaultControlsSettings()
        {
        }

        public IBuildItemControlsSettings BuildItem => DefaultBuildItemControlsSettings.Instance;

        public IHorizontalSnapControlsSettings HorizontalSnap => DefaultHorizontalSnapControlsSettings.Instance;

        public IVerticalSnapControlsSettings VerticalSnap => DefaultVerticalSnapControlsSettings.Instance;
    }
}