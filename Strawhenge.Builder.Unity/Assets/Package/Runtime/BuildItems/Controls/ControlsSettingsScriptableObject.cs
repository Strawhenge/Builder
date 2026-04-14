using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/Controls Settings")]
    public class ControlsSettingsScriptableObject : ScriptableObject, IControlsSettings
    {
        [SerializeField] SerializedBuildItemControlsSettings _buildItem;
        [SerializeField] SerializedHorizontalSnapControlsSettings _horizontalSnap;
        [SerializeField] SerializedVerticalSnapControlsSettings _verticalSnap;

        public IBuildItemControlsSettings BuildItem => _buildItem;

        public IHorizontalSnapControlsSettings HorizontalSnap => _horizontalSnap;

        public IVerticalSnapControlsSettings VerticalSnap => _verticalSnap;
    }
}