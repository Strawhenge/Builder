using Strawhenge.Builder.Unity.BuildItems.Controls.BuildItem;
using Strawhenge.Builder.Unity.BuildItems.Controls.HorizontalSnap;
using Strawhenge.Builder.Unity.BuildItems.Controls.VerticalSnap;

namespace Strawhenge.Builder.Unity.BuildItems.Controls
{
    public interface IControlsSettings
    {
        IBuildItemControlsSettings BuildItem { get; }

        IHorizontalSnapControlsSettings HorizontalSnap { get; }

        IVerticalSnapControlsSettings VerticalSnap { get; }
    }
}