using Strawhenge.Builder.Unity.BuildItems.Snapping;
using Strawhenge.Builder.Unity.ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class HorizontalSnapScript : MonoBehaviour
    {
        [SerializeField] HorizontalSnapSettingsScriptableObject _settings;

        SnapPoint _snapPoint;
        List<Collider> _collidingWith;
        FloatRange _turnRange;

        public IEnumerable<HorizontalSnap> GetAvailableSnaps()
        {
            return _collidingWith
                .Select(x => new HorizontalSnap(_snapPoint, x.transform, _turnRange))
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
            _snapPoint = new SnapPoint(transform);
            _collidingWith = new List<Collider>();
            _turnRange = GetTurnRangeFromSettings();
        }

        void OnTriggerEnter(Collider other)
        {
            _collidingWith.Add(other);
        }

        void OnTriggerExit(Collider other)
        {
            _collidingWith.Remove(other);
        }

        FloatRange GetTurnRangeFromSettings()
        {
            var settings = _settings as IHorizontalSnapSettings;

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