using Strawhenge.Builder.Unity.BuildItems.Snapping;
using System;

namespace Strawhenge.Builder.Unity.BuildItems
{
    class ControlsToggle
    {
        readonly IBuildItemControls _buildItemControls;
        readonly IWallSideSnapControls _verticalSnapControls;
        readonly IFloorEdgeSnapControls _horizontalSnapControls;

        Action _controlsOffStrategy = () => { };

        public ControlsToggle(
            IBuildItemControls buildItemControls,
            IWallSideSnapControls verticalSnapControls,
            IFloorEdgeSnapControls horizontalSnapControls)
        {
            _buildItemControls = buildItemControls;
            _verticalSnapControls = verticalSnapControls;
            _horizontalSnapControls = horizontalSnapControls;
        }

        internal event Action Place;
        internal event Action Snap;
        internal event Action ReleaseSnap;

        internal void BuildControlsOn(IBuildItemPreview buildItem)
        {
            ControlsOff();

            _buildItemControls.Place += InvokePlace;
            _buildItemControls.Snap += InvokeSnap;
            _buildItemControls.ControlOn(buildItem);

            _controlsOffStrategy = () =>
            {
                _buildItemControls.Place -= InvokePlace;
                _buildItemControls.Snap -= InvokeSnap;
                _buildItemControls.ControlOff();
            };
        }

        internal void VerticalSnapControlsOn(WallSideSnap snap)
        {
            ControlsOff();

            _verticalSnapControls.Place += InvokePlace;
            _verticalSnapControls.Release += InvokeReleaseSnap;
            _verticalSnapControls.ControlOn(snap);

            _controlsOffStrategy = () =>
            {
                _verticalSnapControls.Place -= InvokePlace;
                _verticalSnapControls.Release -= InvokeReleaseSnap;
                _verticalSnapControls.ControlOff();
            };
        }

        internal void HorizontalSnapControlsOn(FloorEdgeSnap snap)
        {
            ControlsOff();

            _horizontalSnapControls.Place += InvokePlace;
            _horizontalSnapControls.Release += InvokeReleaseSnap;
            _horizontalSnapControls.ControlOn(snap);

            _controlsOffStrategy = () =>
            {
                _horizontalSnapControls.Place -= InvokePlace;
                _horizontalSnapControls.Release -= InvokeReleaseSnap;
                _horizontalSnapControls.ControlOff();
            };
        }

        internal void ControlsOff()
        {
            _controlsOffStrategy();
            _controlsOffStrategy = () => { };
        }

        void InvokePlace() => Place?.Invoke();

        void InvokeSnap() => Snap?.Invoke();

        void InvokeReleaseSnap() => ReleaseSnap?.Invoke();
    }
}