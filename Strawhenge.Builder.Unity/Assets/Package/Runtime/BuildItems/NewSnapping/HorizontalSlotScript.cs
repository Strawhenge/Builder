using Strawhenge.Common.Unity.Serialization;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.NewSnapping
{
    public class HorizontalSlotScript : MonoBehaviour
    {
        [SerializeField] Transform _snapSlotAnchor;

        [SerializeField] SerializedSource<
            IHorizontalSlotSettings,
            SerializedHorizontalSlotSettings,
            HorizontalSlotSettingsScriptableObject> _settings;

        HorizontalSlot _slot;

        internal HorizontalSlot Slot => _slot ??= Create();

        void Awake()
        {
            var rigidBody = GetComponent<Rigidbody>();
            rigidBody.isKinematic = true;

            foreach (var collider in GetComponents<Collider>())
                collider.isTrigger = true;

            _slot ??= Create();
        }

        HorizontalSlot Create()
        {
            var anchor = _snapSlotAnchor != null
                ? _snapSlotAnchor
                : transform;

            var slideLength = transform.lossyScale.x;

            var settings = _settings.GetValue(); // TODO Handle missing.

            return new HorizontalSlot(
                anchor,
                slideLength,
                settings.CanFlip,
                settings.TiltRange);
        }
    }
}