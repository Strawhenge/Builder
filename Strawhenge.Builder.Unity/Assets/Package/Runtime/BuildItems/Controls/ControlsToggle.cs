using Strawhenge.Builder.Unity.BuildItems.Snapping;
using System;

namespace Strawhenge.Builder.Unity.BuildItems
{
    class ControlsToggle
    {
        readonly IBuildItemControls _buildItemControls;
        readonly IVerticalSnapControls _verticalSnapControls;
        readonly IHorizontalSnapControls _horizontalSnapControls;

        Action _controlsOffStrategy = () => { };

        public ControlsToggle(
            IBuildItemControls buildItemControls,
            IVerticalSnapControls verticalSnapControls,
            IHorizontalSnapControls horizontalSnapControls)
        {
            _buildItemControls = buildItemControls;
            _verticalSnapControls = verticalSnapControls;
            _horizontalSnapControls = horizontalSnapControls;
        }

        internal event Action Place;
        internal event Action Snap;
        internal event Action ReleaseSnap;
        internal event Action Cancel;

        internal void BuildControlsOn(IArrangeBuildItem buildItem)
        {
            ControlsOff();

            _buildItemControls.Place += InvokePlace;
            _buildItemControls.Snap += InvokeSnap;
            _buildItemControls.Cancel += InvokeCancel;
            _buildItemControls.ControlOn(buildItem);
            buildItem.Enable();

            _controlsOffStrategy = () =>
            {
                buildItem.Disable();
                _buildItemControls.Place -= InvokePlace;
                _buildItemControls.Snap -= InvokeSnap;
                _buildItemControls.Cancel -= InvokeCancel;
                _buildItemControls.ControlOff();
            };
        }

        internal void VerticalSnapControlsOn(VerticalSnap snap)
        {
            ControlsOff();

            _verticalSnapControls.Place += InvokePlace;
            _verticalSnapControls.Release += InvokeReleaseSnap;
            _verticalSnapControls.Cancel += InvokeCancel;
            _verticalSnapControls.ControlOn(snap);

            _controlsOffStrategy = () =>
            {
                _verticalSnapControls.Place -= InvokePlace;
                _verticalSnapControls.Release -= InvokeReleaseSnap;
                _verticalSnapControls.Cancel -= InvokeCancel;
                _verticalSnapControls.ControlOff();
            };
        }

        internal void HorizontalSnapControlsOn(HorizontalSnap snap)
        {
            ControlsOff();

            _horizontalSnapControls.Place += InvokePlace;
            _horizontalSnapControls.Release += InvokeReleaseSnap;
            _horizontalSnapControls.Cancel += InvokeCancel;
            _horizontalSnapControls.ControlOn(snap);

            _controlsOffStrategy = () =>
            {
                _horizontalSnapControls.Place -= InvokePlace;
                _horizontalSnapControls.Release -= InvokeReleaseSnap;
                _horizontalSnapControls.Cancel -= InvokeCancel;
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

        void InvokeCancel() => Cancel?.Invoke();
    }
}