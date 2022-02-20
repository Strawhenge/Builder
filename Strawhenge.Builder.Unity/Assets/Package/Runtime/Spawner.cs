using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class Spawner : ISpawner
    {
        public void Despawn(GameObject prefab)
        {
            Object.Destroy(prefab);
        }

        public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            var result = Object.Instantiate(prefab);
            result.transform.SetPositionAndRotation(position, rotation);
            return result;
        }

        public T Spawn<T>(T prefab, Vector3 position, Quaternion rotation) where T : MonoBehaviour
        {
            var result = Object.Instantiate(prefab);
            result.transform.SetPositionAndRotation(position, rotation);
            return result;
        }
    }
}
