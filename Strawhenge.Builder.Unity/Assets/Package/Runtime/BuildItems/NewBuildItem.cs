using Strawhenge.Builder.Unity.Monobehaviours;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class NewBuildItem : IBuildItem
    {
        readonly IDefaultPositionAccessor _initialPosition;
        readonly BuildItemScript _prefab;

        BuildItemScript _current;

        public NewBuildItem(IDefaultPositionAccessor initialPosition, BuildItemScript prefab)
        {
            _initialPosition = initialPosition;
            _prefab = prefab;
        }

        public IArrangeBuildItem Arrange()
        {
            if (_current != null)
            {
                return _current.Arrange;
            }

            _current = Object.Instantiate(
                _prefab,
                _initialPosition.GetPosition(),
                _initialPosition.GetRotation());

            return _current.Arrange;
        }

        public void Cancel() => DestroyCurrent();

        public void PlaceFinal()
        {
            var transform = _current.transform;
            var position = transform.position;
            var rotation = transform.rotation;

            DestroyCurrent();

            Object.Instantiate(_prefab, position, rotation);
        }

        void DestroyCurrent()
        {
            if (_current == null)
                return;

            Object.Destroy(_current.gameObject);
            _current = null;
        }
    }
}