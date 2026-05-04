namespace Strawhenge.Builder.Unity.BuildItems.Controls.HorizontalSnap
{
    class DefaultHorizontalSnapControlsSettings : IHorizontalSnapControlsSettings
    {
        public static IHorizontalSnapControlsSettings Instance { get; } = new DefaultHorizontalSnapControlsSettings();

        DefaultHorizontalSnapControlsSettings()
        {
        }

        public const float TiltSpeed = 1;
        public const float SlideSpeed = 0.1f;

        float IHorizontalSnapControlsSettings.TiltSpeed => TiltSpeed;

        float IHorizontalSnapControlsSettings.SlideSpeed => SlideSpeed;
    }
}