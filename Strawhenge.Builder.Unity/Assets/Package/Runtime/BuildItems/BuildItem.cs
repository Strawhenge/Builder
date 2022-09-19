using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Builder.Unity.ScriptableObjects;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class BuildItem : IBuildItem
    {
        private readonly BuildItemScriptableObject prefabs;

        private BuildItemScript currentPreview;

        public BuildItem(BuildItemScriptableObject prefabs)
        {
            this.prefabs = prefabs;
        }

        public IBuildItemPreview SpawnPreviewItem(Vector3 position, Quaternion rotation)
        {
            if (currentPreview != null)
            {
                return currentPreview.BuildItemPreview;
            }

            currentPreview = Object.Instantiate(prefabs.PreviewItem, position, rotation);

            return currentPreview.BuildItemPreview;
        }

        public void DespawnPreviewItem()
        {
            if (currentPreview == null) return;

            Object.Destroy(currentPreview.gameObject);
        }

        public void SpawnFinalItem(Vector3 position, Quaternion rotation)
        {
            Object.Instantiate(prefabs.FinalItem, position, rotation);
        }
    }
}