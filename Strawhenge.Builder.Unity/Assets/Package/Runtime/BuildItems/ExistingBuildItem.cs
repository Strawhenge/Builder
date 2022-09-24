using Strawhenge.Builder.Unity.Monobehaviours;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class ExistingBuildItem : IBuildItem
    {
        readonly BuildItemScript _script;

        Vector3 _initialPosition;
        Quaternion _initialRotation;

        public ExistingBuildItem(BuildItemScript script)
        {
            _script = script;

            _initialPosition = _script.transform.position;
            _initialRotation = _script.transform.rotation;
        }

        public void Cancel()
        {
            _script.transform.SetPositionAndRotation(_initialPosition, _initialRotation);
        }

        public void Finalize(Vector3 position, Quaternion rotation)
        {
            _initialPosition = _script.transform.position;
            _initialRotation = _script.transform.rotation;
        }

        public IBuildItemPreview Preview(Vector3 position, Quaternion rotation)
        {
            _script.transform.SetPositionAndRotation(position, rotation);

            return _script.BuildItemPreview;
        }
    }
}