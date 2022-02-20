using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests
{
    public static class GameObjectCreator
    {
        private static readonly List<GameObject> createdGameObjects = new List<GameObject>();

        public static GameObject Create(Transform parent = null) => Create(Vector3.zero, Vector3.forward, parent);

        public static GameObject Create(Vector3 position, Transform parent = null) => Create(position, Vector3.forward, parent);

        public static GameObject Create(Vector3 position, Vector3 direction, Transform parent = null) => Create(position, direction, null, parent);

        public static GameObject Create(Vector3 position, Quaternion rotation, Transform parent = null) => Create(position, null, rotation, parent);

        private static GameObject Create(Vector3 position, Vector3? direction, Quaternion? rotation, Transform parent)
        {
            var gameObject = new GameObject();

            gameObject.transform.position = position;

            if (direction.HasValue)
                gameObject.transform.forward = direction.Value;

            if (rotation.HasValue)
                gameObject.transform.rotation = rotation.Value;

            gameObject.transform.parent = parent;

            createdGameObjects.Add(gameObject);

            return gameObject;
        }

        public static void DestroyAll()
        {
            var gameObjects = createdGameObjects.ToArray();
            createdGameObjects.Clear();

            foreach (var gameObject in gameObjects)
            {
                Object.DestroyImmediate(gameObject);
            }
        }
    }
}
