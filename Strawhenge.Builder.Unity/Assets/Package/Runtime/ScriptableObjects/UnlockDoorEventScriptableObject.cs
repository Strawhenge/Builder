using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Common.Unity;
using UnityEngine;

namespace Strawhenge.Builder.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/Events/Unlock Door")]
    public class UnlockDoorEventScriptableObject : EventScriptableObject
    {
        public override void Invoke(GameObject gameObject)
        {
            var door = gameObject.GetComponentInChildren<DoorScript>();

            if (door != null)
                door.Unlock();
        }
    }
}