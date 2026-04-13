using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class ControlsScript : MonoBehaviour
    {
        [SerializeField] BuildItemControlsSettings _buildItemSettings;
        [SerializeField] VerticalSnapControlsSettings _verticalSnapSettings;
        [SerializeField] HorizontalSnapControlsSettings _horizontalSnapSettings;

        BuildItemControls _buildItemControls;
        VerticalSnapControls _verticalSnapControls;
        HorizontalSnapControls _horizontalSnapControls;

        public BuildItemControls BuildItemControls => _buildItemControls ??= CreateBuildItemControls();

        public VerticalSnapControls VerticalSnapControls => _verticalSnapControls ??= CreateVerticalSnapControls();

        public HorizontalSnapControls HorizontalSnapControls =>
            _horizontalSnapControls ??= CreateHorizontalSnapControls();

        BuildItemControls CreateBuildItemControls()
        {
            return new BuildItemControls(_buildItemSettings);
        }

        VerticalSnapControls CreateVerticalSnapControls()
        {
            return new VerticalSnapControls(_verticalSnapSettings);
        }

        HorizontalSnapControls CreateHorizontalSnapControls()
        {
            return new HorizontalSnapControls(_horizontalSnapSettings);
        }
    }
}