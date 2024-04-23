using Strawhenge.Builder.Unity.Monobehaviours;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class NewBuildItem : IBuildItem
    {
        readonly IBuilderProgressTracker _progressTracker;
        readonly IDefaultPositionAccessor _initialPosition;
        readonly BuildItemScript _prefab;
        readonly string _blueprintName;

        BuildItemScript _current;

        public NewBuildItem(
            IBuilderProgressTracker progressTracker,
            IDefaultPositionAccessor initialPosition,
            BuildItemScript prefab,
            string blueprintName)
        {
            _progressTracker = progressTracker;
            _initialPosition = initialPosition;
            _prefab = prefab;
            _blueprintName = blueprintName;
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

            _current.SetArranging();
            return _current.Arrange;
        }

        public void Cancel() => DestroyCurrent();

        public void PlaceFinal()
        {
            _current.SetPlaced();
            _current = null;

            _progressTracker.Add(_current, _blueprintName);
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