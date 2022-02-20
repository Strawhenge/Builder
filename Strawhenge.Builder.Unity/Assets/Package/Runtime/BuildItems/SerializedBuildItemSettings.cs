using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    [Serializable]
    public class SerializedBuildItemSettings : IBuildItemSettings
    {
        [SerializeField]
        float minTiltAngle;

        [SerializeField]
        float maxTiltAngle;

        float IBuildItemSettings.MinTiltAngle => minTiltAngle;

        float IBuildItemSettings.MaxTiltAngle => maxTiltAngle;
    }
}