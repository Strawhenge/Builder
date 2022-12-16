using Strawhenge.Builder.Unity.BuildItems;
using System;

namespace Strawhenge.Builder.Unity.Tests.Fakes
{
    class BuildItemControllerFake : IBuildItemController
    {
        Action _onPlacedItem;
        Action _onCancel;

        internal bool IsOn { get; private set; }

        public void Off()
        {
            SetOffState(_onCancel);
        }

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

        public void On(
            IExistingBuildItem buildItem,
            Action onPlacedItem = null,
            Action onScrapped = null,
            Action onCancelled = null) =>
            On((IBuildItem)buildItem, onPlacedItem: onPlacedItem, onCancelled: onCancelled);

        internal void InvokePlaceItem()
        {
            SetOffState(_onPlacedItem);
        }

        internal void InvokeCancel()
        {
            SetOffState(_onCancel);
        }

        void SetOffState(Action callback)
        {
            IsOn = false;
            _onCancel = null;
            _onPlacedItem = null;
            callback?.Invoke();
        }
    }
}