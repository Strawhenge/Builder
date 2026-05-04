namespace Strawhenge.Builder.Unity.BuildItems.Controls.BuildItem
{
    class DefaultBuildItemControlsSettings : IBuildItemControlsSettings
    {
        public static IBuildItemControlsSettings Instance { get; } = new DefaultBuildItemControlsSettings();

        DefaultBuildItemControlsSettings()
        {
        }

        public const float MoveSpeed = 5;
        public const float TurnSpeed = 2;

        float IBuildItemControlsSettings.MoveSpeed => MoveSpeed;

        float IBuildItemControlsSettings.TurnSpeed => TurnSpeed;
    }
}