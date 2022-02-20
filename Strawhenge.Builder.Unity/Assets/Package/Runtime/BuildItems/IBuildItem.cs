using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public interface IBuildItem
    {
        void DespawnPreviewItem();

        void SpawnFinalItem(Vector3 position, Quaternion rotation);

        IBuildItemPreview SpawnPreviewItem(Vector3 position, Quaternion rotation);
    }
}