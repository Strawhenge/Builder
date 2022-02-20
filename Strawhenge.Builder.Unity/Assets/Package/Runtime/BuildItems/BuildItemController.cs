using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class BuildItemController : IBuildItemController
    {
        private IBuildItem currentBuildItem;

        public Maybe<IBuildItemPreview> CurrentPreview { get; private set; } = Maybe.None<IBuildItemPreview>();

        public void PreviewOn(IBuildItem buildItem, Vector3 position, Quaternion rotation)
        {
            currentBuildItem?.DespawnPreviewItem();
            currentBuildItem = buildItem;

            var preview = buildItem.SpawnPreviewItem(position, rotation);

            CurrentPreview = Maybe.Some(preview);
        }

        public void PreviewOff()
        {
            currentBuildItem?.DespawnPreviewItem();
            currentBuildItem = null;

            CurrentPreview = Maybe.None<IBuildItemPreview>();
        }

        public void SpawnFinalItem() => CurrentPreview.Do(SpawnFinalItem);

        private void SpawnFinalItem(IBuildItemPreview preview)
        {
            if (currentBuildItem == null) return;

            currentBuildItem.SpawnFinalItem(
                preview.Position,
                preview.Rotation);
        }
    }
}