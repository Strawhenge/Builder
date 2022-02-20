using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class NullBuildItem : IBuildItem
    {
        public void DespawnPreviewItem()
        {
        }

        public void SpawnFinalItem(Vector3 position, Quaternion rotation)
        {
        }

        public IBuildItemPreview SpawnPreviewItem(Vector3 position, Quaternion rotation) => new NullBuildItemPreview();
    }
}