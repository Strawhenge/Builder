using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class BuildItemController : IBuildItemController
    {
        private IBuildItem currentBuildItem;

        public Maybe<IBuildItemPreview> CurrentPreview { get; private set; } = Maybe.None<IBuildItemPreview>();

        public void PreviewOn(IBuildItem buildItem)
        {
            currentBuildItem?.Cancel();
            currentBuildItem = buildItem;

            var preview = buildItem.Preview();

            CurrentPreview = Maybe.Some(preview);
        }

        public void PreviewOff()
        {
            currentBuildItem?.Cancel();
            currentBuildItem = null;

            CurrentPreview = Maybe.None<IBuildItemPreview>();
        }

        public void SpawnFinalItem() => CurrentPreview.Do(SpawnFinalItem);

        void SpawnFinalItem(IBuildItemPreview preview)
        {
            if (currentBuildItem == null) return;

            currentBuildItem.PlaceFinal();
            currentBuildItem = null;

            CurrentPreview = Maybe.None<IBuildItemPreview>();
        }
    }
}