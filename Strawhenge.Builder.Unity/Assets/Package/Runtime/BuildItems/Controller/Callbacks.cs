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
            Action _onScrapped;

            public Callbacks()
            {
                Set();
            }

            public void Set(
                Func<bool> canPlaceItem = null,
                Action onPlacedItem = null,
                Action onCancelled = null,
                Action onScrapped = null)
            {
                _canPlacedItem = canPlaceItem ?? (() => true);
                _onPlacedFinalItem = onPlacedItem ?? (() => { });
                _onCancelled = onCancelled ?? (() => { });
                _onScrapped = onScrapped ?? (() => { });
            }

            public bool CanPlaceItem() => _canPlacedItem();

            public void OnPlacedItem() => Invoke(_onPlacedFinalItem);

            public void OnCancelled() => Invoke(_onCancelled);

            public void OnScrapped() => Invoke(_onScrapped);

            void Invoke(Action action)
            {
                Set();
                action();
            }
        }
    }
}