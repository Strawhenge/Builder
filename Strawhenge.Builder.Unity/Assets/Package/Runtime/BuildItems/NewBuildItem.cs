using Strawhenge.Builder.Unity.Monobehaviours;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class NewBuildItem : IBuildItem
    {
        readonly BuildItemScript _prefab;

        BuildItemScript _currentPreview;

        public NewBuildItem(BuildItemScript prefab)
        {
            _prefab = prefab;
        }

        public IBuildItemPreview Preview(Vector3 position, Quaternion rotation)
        {
            if (_currentPreview != null)
            {
                return _currentPreview.BuildItemPreview;
            }

            _currentPreview = Object.Instantiate(_prefab, position, rotation);

            return _currentPreview.BuildItemPreview;
        }

        public void Cancel() => DestroyPreviewObject();

        public void Finalize(Vector3 position, Quaternion rotation)
        {
            DestroyPreviewObject();

            Object.Instantiate(_prefab, position, rotation);
        }

        void DestroyPreviewObject()
        {
            if (_currentPreview == null)
                return;

            Object.Destroy(_currentPreview.gameObject);
            _currentPreview = null;
        }
    }
}