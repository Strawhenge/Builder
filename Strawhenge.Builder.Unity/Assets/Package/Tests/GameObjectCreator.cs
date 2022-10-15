using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests
{
    public static class GameObjectCreator
    {
        public static GameObject Create(Transform parent = null) => Create(Vector3.zero, Vector3.forward, parent);

        public static GameObject Create(Vector3 position, Transform parent = null) =>
            Create(position, Vector3.forward, parent);

        public static GameObject Create(Vector3 position, Vector3 direction, Transform parent = null) =>
            Create(position, direction, null, parent);

        public static GameObject Create(Vector3 position, Quaternion rotation, Transform parent = null) =>
            Create(position, null, rotation, parent);

        static GameObject Create(Vector3 position, Vector3? direction, Quaternion? rotation, Transform parent)
        {
            var gameObject = new GameObject();
            gameObject.transform.position = position;

            if (direction.HasValue)
                gameObject.transform.forward = direction.Value;

            if (rotation.HasValue)
                gameObject.transform.rotation = rotation.Value;

            gameObject.transform.parent = parent;

            return gameObject;
        }
    }
}