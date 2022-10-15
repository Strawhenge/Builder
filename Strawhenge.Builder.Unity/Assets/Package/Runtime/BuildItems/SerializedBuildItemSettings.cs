using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    [Serializable]
    public class SerializedBuildItemSettings : IBuildItemSettings
    {
        [SerializeField] float _minTiltAngle;
        [SerializeField] float _maxTiltAngle;

        float IBuildItemSettings.MinTiltAngle => _minTiltAngle;

        float IBuildItemSettings.MaxTiltAngle => _maxTiltAngle;
    }
}