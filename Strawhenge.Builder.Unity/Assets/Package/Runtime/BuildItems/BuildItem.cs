using Strawhenge.Builder.Unity.Monobehaviours;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class BuildItem : IBuildItem
    {
        readonly BuildItemScript _prefab;

        BuildItemScript _currentPreview;

        public BuildItem(BuildItemScript prefab)
        {
            _prefab = prefab;
        }

        public IBuildItemPreview SpawnPreviewItem(Vector3 position, Quaternion rotation)
        {
            if (_currentPreview != null)
            {
                return _currentPreview.BuildItemPreview;
            }

            _currentPreview = Object.Instantiate(_prefab, position, rotation);

            return _currentPreview.BuildItemPreview;
        }

        public void DespawnPreviewItem()
        {
            if (_currentPreview == null)
                return;

            Object.Destroy(_currentPreview.gameObject);
        }

        public void SpawnFinalItem(Vector3 position, Quaternion rotation)
        {
            Object.Instantiate(_prefab, position, rotation);
        }
    }
}