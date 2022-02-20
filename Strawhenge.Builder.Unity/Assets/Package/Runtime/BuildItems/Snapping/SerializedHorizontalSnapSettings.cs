using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    public class SerializedHorizontalSnapSettings : IHorizontalSnapSettings
    {
        [SerializeField]
        float minTurnAngle;

        [SerializeField]
        float maxTurnAngle;

        float IHorizontalSnapSettings.MinTurnAngle => minTurnAngle;

        float IHorizontalSnapSettings.MaxTurnAngle => maxTurnAngle;
    }    
}