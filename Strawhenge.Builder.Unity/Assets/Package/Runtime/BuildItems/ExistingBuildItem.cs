using Strawhenge.Builder.Unity.Monobehaviours;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class ExistingBuildItem : IExistingBuildItem
    {
        readonly BuildItemScript _script;

        Vector3 _initialPosition;
        Quaternion _initialRotation;

        public ExistingBuildItem(BuildItemScript script)
        {
            _script = script;

            var transform = _script.transform;
            _initialPosition = transform.position;
            _initialRotation = transform.rotation;
        }

        public void Cancel()
        {
            _script.SetPlaced();
            _script.transform.SetPositionAndRotation(_initialPosition, _initialRotation);
        }

        public void PlaceFinal()
        {
            _script.SetPlaced();
            var transform = _script.transform;
            _initialPosition = transform.position;
            _initialRotation = transform.rotation;
        }

        public IArrangeBuildItem Arrange()
        {
            _script.SetArranging();
            return _script.Arrange;
        }

        public void Scrap()
        {
            Object.Destroy(_script.gameObject);
        }
    }
}