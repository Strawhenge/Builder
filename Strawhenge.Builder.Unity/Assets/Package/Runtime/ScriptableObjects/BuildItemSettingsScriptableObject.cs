using Strawhenge.Builder.Unity.BuildItems;
using UnityEngine;

namespace Strawhenge.Builder.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/BuildItemSettings")]
    public class BuildItemSettingsScriptableObject : ScriptableObject, IBuildItemSettings
    {
        [SerializeField]
        float minTiltAngle;

        [SerializeField]
        float maxTiltAngle;

        float IBuildItemSettings.MinTiltAngle => minTiltAngle;

        float IBuildItemSettings.MaxTiltAngle => maxTiltAngle;
    }
}
