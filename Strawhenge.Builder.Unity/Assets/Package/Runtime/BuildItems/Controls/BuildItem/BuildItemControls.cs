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

        internal event Action Place;
        internal event Action Snap;
        internal event Action Cancel;
        internal event Action Scrap;

        public bool IsEnabled => _buildItem != null;

        public void Move(Vector3 moveInput) => _buildItem.Move(moveInput * _moveSpeed);

        public void Turn(float amount) => _buildItem.Turn(amount * _turnSpeed);

        public void InvokePlace() => Place?.Invoke();

        public void InvokeCancel() => Cancel?.Invoke();

        public void InvokeScrap() => Scrap?.Invoke();

        public void InvokeSnap() => Snap?.Invoke();

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