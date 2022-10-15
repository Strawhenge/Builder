using Strawhenge.Builder.Unity.BuildItems.Snapping;
using UnityEngine;

namespace Strawhenge.Builder.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/HorizontalSnapSettings")]
    public class HorizontalSnapSettingsScriptableObject : ScriptableObject, IHorizontalSnapSettings
    {
        [SerializeField] float _minTurnAngle;
        [SerializeField] float _maxTurnAngle;

        float IHorizontalSnapSettings.MinTurnAngle => _minTurnAngle;

        float IHorizontalSnapSettings.MaxTurnAngle => _maxTurnAngle;
    }
}