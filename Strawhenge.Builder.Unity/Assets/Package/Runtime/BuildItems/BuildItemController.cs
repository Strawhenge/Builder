using System;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class BuildItemController : IBuildItemController
    {
        IBuildItem _currentBuildItem;
        Func<bool> _canPlaceFinalItem;
        Action _onPlacedFinalItem;
        Action _onCancelled;

        public BuildItemController()
        {
            ResetCallbacks();
        }

        public Maybe<IBuildItemPreview> CurrentPreview { get; private set; } = Maybe.None<IBuildItemPreview>();

        public void PreviewOn(IBuildItem buildItem, Func<bool> canPlaceFinalItem = null, Action onPlacedFinalItem = null, Action onCancelled = null)
        {
            _currentBuildItem?.Cancel();
            _currentBuildItem = buildItem;

            _canPlaceFinalItem = canPlaceFinalItem ?? (() => true);
            _onPlacedFinalItem = onPlacedFinalItem ?? (() => { });
            _onCancelled = onCancelled ?? (() => { });

            var preview = buildItem.Preview();

            CurrentPreview = Maybe.Some(preview);
        }

        public void PreviewOff()
        {
            _currentBuildItem?.Cancel();
            _currentBuildItem = null;

            CurrentPreview = Maybe.None<IBuildItemPreview>();

            _onCancelled();
            ResetCallbacks();
        }

        public void SpawnFinalItem() => CurrentPreview.Do(SpawnFinalItem);

        void SpawnFinalItem(IBuildItemPreview preview)
        {
            if (_currentBuildItem == null || !_canPlaceFinalItem())
                return;

            _currentBuildItem.PlaceFinal();
            _currentBuildItem = null;

            CurrentPreview = Maybe.None<IBuildItemPreview>();

            _onPlacedFinalItem();
            ResetCallbacks();
        }

        void ResetCallbacks()
        {
            _canPlaceFinalItem = () => true;
            _onPlacedFinalItem = () => { };
            _onCancelled = () => { };
        }
    }
}