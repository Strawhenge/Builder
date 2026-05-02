using Strawhenge.Builder.Unity.BuildItems.Arrange;
using Strawhenge.Builder.Unity.BuildItems.DefaultPosition;
using Strawhenge.Builder.Unity.Progress;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.New
{
    class NewBuildItem : IBuildItem
    {
        readonly BuilderProgressTracker _progressTracker;
        readonly IDefaultPositionAccessor _initialPosition;
        readonly BuildItemScript _prefab;
        readonly string _blueprintName;
        readonly Transform _buildItemsParent;

        BuildItemScript _current;

        public NewBuildItem(
            BuilderProgressTracker progressTracker,
            IDefaultPositionAccessor initialPosition,
            BuildItemScript prefab,
            string blueprintName,
            Transform buildItemsParent)
        {
            _progressTracker = progressTracker;
            _initialPosition = initialPosition;
            _prefab = prefab;
            _blueprintName = blueprintName;
            _buildItemsParent = buildItemsParent;
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
                _initialPosition.GetRotation(),
                _buildItemsParent);

            _current.SetArranging();
            return _current.Arrange;
        }

        public void Cancel() => DestroyCurrent();

        public void PlaceFinal()
        {
            _current.SetPlaced();
            _progressTracker.Add(_current, _blueprintName);

            _current = null;
        }

        void DestroyCurrent()
        {
            if (_current == null)
                return;

            ObjectHelper.Destroy(_current.gameObject);
            _current = null;
        }
    }
}