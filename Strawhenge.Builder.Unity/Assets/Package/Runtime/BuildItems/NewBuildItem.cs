using Strawhenge.Builder.Unity.Monobehaviours;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class NewBuildItem : IBuildItem
    {
        readonly IDefaultPositionAccessor _initialPosition;
        readonly BuildItemScript _prefab;

        BuildItemScript _currentPreview;

        public NewBuildItem(IDefaultPositionAccessor initialPosition, BuildItemScript prefab)
        {
            _initialPosition = initialPosition;
            _prefab = prefab;
        }

        public IBuildItemPreview Preview()
        {
            if (_currentPreview != null)
            {
                return _currentPreview.BuildItemPreview;
            }

            _currentPreview = Object.Instantiate(
                _prefab, 
                _initialPosition.GetPosition(), 
                _initialPosition.GetRotation());

            return _currentPreview.BuildItemPreview;
        }

        public void Cancel() => DestroyPreviewObject();

        public void PlaceFinal()
        {
            var transform = _currentPreview.transform;
            var position = transform.position;
            var rotation = transform.rotation;

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