using System;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public partial class BuildItemController
    {
        class Callbacks
        {
            Func<bool> _canPlacedItem;
            Action _onPlacedFinalItem;
            Action _onCancelled;

            public Callbacks()
            {
                Set();
            }

            public void Set(
                Func<bool> canPlaceItem = null,
                Action onPlacedItem = null,
                Action onCancelled = null)
            {
                _canPlacedItem = canPlaceItem ?? (() => true);
                _onPlacedFinalItem = onPlacedItem ?? (() => { });
                _onCancelled = onCancelled ?? (() => { });
            }

            public bool CanPlaceItem() => _canPlacedItem();

            public void OnPlacedItem() => Invoke(_onPlacedFinalItem);

            public void OnCancelled() => Invoke(_onCancelled);

            void Invoke(Action action)
            {
                Set();
                action();
            }
        }
    }
}