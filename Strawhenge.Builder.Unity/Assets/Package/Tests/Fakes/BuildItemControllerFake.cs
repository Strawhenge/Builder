using Strawhenge.Builder.Unity.BuildItems;
using System;

namespace Strawhenge.Builder.Unity.Tests.Fakes
{
    class BuildItemControllerFake : IBuildItemController
    {
        Action _onPlacedItem;
        Action _onCancel;

        internal bool IsOn { get; private set; }

        public void Off() => IsOn = false;

        public void On(
            IBuildItem buildItem,
            Func<bool> canPlaceItem = null,
            Action onPlacedItem = null,
            Action onCancelled = null)
        {
            IsOn = true;
            _onPlacedItem = onPlacedItem;
            _onCancel = onCancelled;
        }

        internal void InvokePlaceItem()
        {
            _onPlacedItem?.Invoke();
            IsOn = false;
        }

        internal void InvokeCancel()
        {
            _onCancel?.Invoke();
            IsOn = false;
        }
    }
}
