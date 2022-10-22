using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class FloorEdgeSlotScript : BaseSlotScript
    {
        [SerializeField] bool _canFlip;

        public bool CanFlip => _canFlip;
    }
}