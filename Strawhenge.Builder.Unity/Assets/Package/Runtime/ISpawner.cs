using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public interface ISpawner
    {
        void Despawn(GameObject prefab);

        GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation);

        T Spawn<T>(T prefab, Vector3 position, Quaternion rotation) where T : MonoBehaviour;
    }
}
