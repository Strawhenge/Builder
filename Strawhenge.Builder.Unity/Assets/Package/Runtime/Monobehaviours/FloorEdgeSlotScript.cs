using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class FloorEdgeSlotScript : BaseSlotScript
    {
        [SerializeField] bool _canFlip;

        public bool CanFlip => _canFlip;
    }
}