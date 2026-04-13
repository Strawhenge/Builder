using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class BuildItemControls
    {
        readonly float _moveSpeed;
        readonly float _turnSpeed;

        IArrangeBuildItem _buildItem;

        public BuildItemControls(BuildItemControlsSettings settings)
        {
            _moveSpeed = settings.MoveSpeed;
            _turnSpeed = settings.TurnSpeed;
        }

        public event Action Enabled;
        public event Action Disabled;

        internal event Action Placed;
        internal event Action Snapped;
        internal event Action Cancelled;
        internal event Action Scrapped;

        public bool IsEnabled => _buildItem != null;

        public void Move(Vector3 moveInput) => _buildItem.Move(moveInput * _moveSpeed);

        public void Turn(float amount) => _buildItem.Turn(amount * _turnSpeed);

        public void Place() => Placed?.Invoke();

        public void Cancel() => Cancelled?.Invoke();

        public void Scrap() => Scrapped?.Invoke();

        public void Snap() => Snapped?.Invoke();

        public void ClippingToggle()
        {
            if (_buildItem.ClippingDisabled)
                _buildItem.ClippingOn();
            else
                _buildItem.ClippingOff();
        }

        internal void ControlOn(IArrangeBuildItem buildItem, bool canScrap) // TODO Why is canScrap needed here?
        {
            _buildItem = buildItem;
            Enabled?.Invoke();
        }

        internal void ControlOff()
        {
            _buildItem = null;
            Disabled?.Invoke();
        }
    }
}