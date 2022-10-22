using UnityEngine;

namespace Strawhenge.Builder.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/SlotSettings/FloorEdge")]
    public class FloorEdgeSlotSettingsScriptableObject : ScriptableObject
    {
        [SerializeField] bool _canFlip;
        [SerializeField] float _minTiltAngle;
        [SerializeField] float _maxTiltAngle;

        public bool CanFlip => _canFlip;

        public float MinTiltAngle => _minTiltAngle;

        public float MaxTiltAngle => _maxTiltAngle;
    }
}