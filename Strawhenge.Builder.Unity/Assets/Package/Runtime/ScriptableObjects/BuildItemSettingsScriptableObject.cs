using Strawhenge.Builder.Unity.BuildItems;
using UnityEngine;
using UnityEngine.Serialization;

namespace Strawhenge.Builder.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/BuildItemSettings")]
    public class BuildItemSettingsScriptableObject : ScriptableObject, IBuildItemSettings
    {
        [SerializeField] float _minTiltAngle;
        [SerializeField] float _maxTiltAngle;

        float IBuildItemSettings.MinTiltAngle => _minTiltAngle;

        float IBuildItemSettings.MaxTiltAngle => _maxTiltAngle;
    }
}