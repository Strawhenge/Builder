using Strawhenge.Builder.Unity.BuildItems.Controls.BuildItem;
using Strawhenge.Builder.Unity.BuildItems.Controls.HorizontalSnap;
using Strawhenge.Builder.Unity.BuildItems.Controls.VerticalSnap;

namespace Strawhenge.Builder.Unity.BuildItems.Controls
{
    public class Controls
    {
        public Controls(IControlsSettings settings)
        {
            BuildItem = new BuildItemControls(settings.BuildItem);
            HorizontalSnap = new HorizontalSnapControls(settings.HorizontalSnap);
            VerticalSnap = new VerticalSnapControls(settings.VerticalSnap);

        }
        
        public BuildItemControls BuildItem { get; }
        
        public HorizontalSnapControls HorizontalSnap { get; }
        
        public VerticalSnapControls VerticalSnap { get; }
    }
}