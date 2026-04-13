using Strawhenge.Builder.Unity.BuildItems.Snapping;
using System;

namespace Strawhenge.Builder.Unity.BuildItems
{
    class ControlsToggle
    {
        readonly BuildItemControls _buildItemControls;
        readonly VerticalSnapControls _verticalSnapControls;
        readonly HorizontalSnapControls _horizontalSnapControls;

        Action _controlsOffStrategy = () => { };

        public ControlsToggle(
            BuildItemControls buildItemControls,
            VerticalSnapControls verticalSnapControls,
            HorizontalSnapControls horizontalSnapControls)
        {
            _buildItemControls = buildItemControls;
            _verticalSnapControls = verticalSnapControls;
            _horizontalSnapControls = horizontalSnapControls;
        }

        internal event Action Place;
        internal event Action Snap;
        internal event Action ReleaseSnap;
        internal event Action Cancel;
        internal event Action Scrap;

        internal void BuildControlsOn(IArrangeBuildItem buildItem, bool canScrap)
        {
            ControlsOff();

            _buildItemControls.Placed += InvokePlace;
            _buildItemControls.Snapped += InvokeSnap;
            _buildItemControls.Cancelled += InvokeCancel;

            if (canScrap)
                _buildItemControls.Scrapped += InvokeScrap;

            _buildItemControls.ControlOn(buildItem, canScrap);
            buildItem.Enable();

            _controlsOffStrategy = () =>
            {
                buildItem.Disable();
                _buildItemControls.Placed -= InvokePlace;
                _buildItemControls.Snapped -= InvokeSnap;
                _buildItemControls.Cancelled -= InvokeCancel;

                if (canScrap)
                    _buildItemControls.Scrapped -= InvokeScrap;

                _buildItemControls.ControlOff();
            };
        }

        internal void VerticalSnapControlsOn(VerticalSnap snap)
        {
            ControlsOff();

            _verticalSnapControls.Placed += InvokePlace;
            _verticalSnapControls.Released += InvokeReleaseSnap;
            _verticalSnapControls.Cancelled += InvokeCancel;
            _verticalSnapControls.ControlOn(snap);

            _controlsOffStrategy = () =>
            {
                _verticalSnapControls.Placed -= InvokePlace;
                _verticalSnapControls.Released -= InvokeReleaseSnap;
                _verticalSnapControls.Cancelled -= InvokeCancel;
                _verticalSnapControls.ControlOff();
            };
        }

        internal void HorizontalSnapControlsOn(HorizontalSnap snap)
        {
            ControlsOff();

            _horizontalSnapControls.Placed += InvokePlace;
            _horizontalSnapControls.Released += InvokeReleaseSnap;
            _horizontalSnapControls.Cancelled += InvokeCancel;
            _horizontalSnapControls.ControlOn(snap);

            _controlsOffStrategy = () =>
            {
                _horizontalSnapControls.Placed -= InvokePlace;
                _horizontalSnapControls.Released -= InvokeReleaseSnap;
                _horizontalSnapControls.Cancelled -= InvokeCancel;
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

        void InvokeScrap() => Scrap?.Invoke();
    }
}