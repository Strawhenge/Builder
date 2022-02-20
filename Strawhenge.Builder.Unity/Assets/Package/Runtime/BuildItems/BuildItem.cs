using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Builder.Unity.ScriptableObjects;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class BuildItem : IBuildItem
    {
        private readonly BuildItemScriptableObject prefabs;
        private readonly ISpawner spawner;

        private BuildItemScript currentPreview;

        public BuildItem(
            BuildItemScriptableObject prefabs,
            ISpawner spawner)
        {
            this.prefabs = prefabs;
            this.spawner = spawner;
        }

        public IBuildItemPreview SpawnPreviewItem(Vector3 position, Quaternion rotation)
        {
            if (currentPreview != null)
            {
                return currentPreview.BuildItemPreview;
            }

            currentPreview = spawner
                .Spawn(prefabs.PreviewItem, position, rotation);

            return currentPreview.BuildItemPreview;
        }

        public void DespawnPreviewItem()
        {
            if (currentPreview == null) return;

            spawner.Despawn(currentPreview.gameObject);
        }

        public void SpawnFinalItem(Vector3 position, Quaternion rotation)
        {
            spawner
                .Spawn(prefabs.FinalItem, position, rotation);
        }
    }
}