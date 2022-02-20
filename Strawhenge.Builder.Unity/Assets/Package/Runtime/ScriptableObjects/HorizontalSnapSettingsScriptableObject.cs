using Strawhenge.Builder.Unity.BuildItems.Snapping;
using UnityEngine;

namespace Strawhenge.Builder.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/HorizontalSnapSettings")]
    public class HorizontalSnapSettingsScriptableObject : ScriptableObject, IHorizontalSnapSettings
    {
        [SerializeField]
        float minTurnAngle;

        [SerializeField]
        float maxTurnAngle;

        float IHorizontalSnapSettings.MinTurnAngle => minTurnAngle;

        float IHorizontalSnapSettings.MaxTurnAngle => maxTurnAngle;
    }
}
