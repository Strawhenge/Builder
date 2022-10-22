using UnityEngine;

namespace Strawhenge.Builder.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/SlotSettings/WallBottom")]
    public class WallBottomSlotSettingsScriptableObject : ScriptableObject
    {
        [SerializeField] float _minTiltAngle;
        [SerializeField] float _maxTiltAngle;

        public float MinTiltAngle => _minTiltAngle;

        public float MaxTiltAngle => _maxTiltAngle;
    }
}