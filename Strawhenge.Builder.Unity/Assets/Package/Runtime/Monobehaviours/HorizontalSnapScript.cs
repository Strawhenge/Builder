using Strawhenge.Builder.Unity.BuildItems.Snapping;
using Strawhenge.Builder.Unity.ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class HorizontalSnapScript : MonoBehaviour
    {
        [SerializeField] HorizontalSnapSettingsScriptableObject _settings;

        SnapPoint snapPoint;
        List<Collider> collidingWith;
        FloatRange turnRange;

        public IEnumerable<HorizontalSnap> GetAvailableSnaps()
        {
            return collidingWith
                .Select(x => new HorizontalSnap(snapPoint, x.transform, turnRange))
                .ToArray();
        }

        void Awake()
        {
            var rigidbody = GetComponent<Rigidbody>();
            rigidbody.isKinematic = true;

            var collider = GetComponent<CapsuleCollider>();
            collider.isTrigger = true;
        }

        void Start()
        {
            snapPoint = new SnapPoint(transform);
            collidingWith = new List<Collider>();
            turnRange = GetTurnRangeFromSettings();
        }

        void OnTriggerEnter(Collider other)
        {
            collidingWith.Add(other);
        }

        void OnTriggerExit(Collider other)
        {
            collidingWith.Remove(other);
        }

        FloatRange GetTurnRangeFromSettings()
        {
            var settings = this._settings as IHorizontalSnapSettings;

            if (!FloatRange.IsValidRange(settings.MinTurnAngle, settings.MaxTurnAngle))
            {
                Debug.LogWarning(
                    $"Invalid tilt angle settings. {nameof(settings.MinTurnAngle)}: {settings.MinTurnAngle}, {nameof(settings.MaxTurnAngle)}: {settings.MaxTurnAngle}",
                    context: this);
                return (0, 0);
            }

            return (settings.MinTurnAngle, settings.MaxTurnAngle);
        }
    }
}