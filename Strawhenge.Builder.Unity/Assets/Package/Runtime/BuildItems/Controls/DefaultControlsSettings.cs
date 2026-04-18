using Strawhenge.Builder.Unity.BuildItems.Controls.BuildItem;
using Strawhenge.Builder.Unity.BuildItems.Controls.HorizontalSnap;
using Strawhenge.Builder.Unity.BuildItems.Controls.VerticalSnap;

namespace Strawhenge.Builder.Unity.BuildItems.Controls
{
    public sealed class DefaultControlsSettings : IControlsSettings
    {
        public static DefaultControlsSettings Instance { get; } = new();

        DefaultControlsSettings()
        {
        }

        public IBuildItemControlsSettings BuildItem => DefaultBuildItemControlsSettings.Instance;

        public IHorizontalSnapControlsSettings HorizontalSnap => DefaultHorizontalSnapControlsSettings.Instance;

        public IVerticalSnapControlsSettings VerticalSnap => DefaultVerticalSnapControlsSettings.Instance;
    }
}