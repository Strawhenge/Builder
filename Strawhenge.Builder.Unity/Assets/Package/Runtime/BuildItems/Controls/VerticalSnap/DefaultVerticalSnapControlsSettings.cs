namespace Strawhenge.Builder.Unity.BuildItems.Controls.VerticalSnap
{
    class DefaultVerticalSnapControlsSettings : IVerticalSnapControlsSettings
    {
        public static IVerticalSnapControlsSettings Instance { get; } = new DefaultVerticalSnapControlsSettings();

        DefaultVerticalSnapControlsSettings()
        {
        }

        public const float TurnSpeed = 1;
        public const float SlideSpeed = 0.1f;

        float IVerticalSnapControlsSettings.TurnSpeed => TurnSpeed;

        float IVerticalSnapControlsSettings.SlideSpeed => SlideSpeed;
    }
}