using Strawhenge.Common.Unity.Serialization;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    public class VerticalSlotScript : MonoBehaviour
    {
        [SerializeField] Transform _snapSlotAnchor;

        [SerializeField] SerializedSource<
            IVerticalSlotSettings,
            SerializedVerticalSlotSettings,
            VerticalSlotSettingsScriptableObject> _settings;

        VerticalSlot _slot;

        internal VerticalSlot Slot => _slot ??= Create();

        void Awake()
        {
            var rigidBody = GetComponent<Rigidbody>();
            rigidBody.isKinematic = true;

            foreach (var collider in GetComponents<Collider>())
                collider.isTrigger = true;

            _slot ??= Create();
        }

        VerticalSlot Create()
        {
            var anchor = _snapSlotAnchor != null
                ? _snapSlotAnchor
                : transform;

            var slideLength = transform.lossyScale.y;

            if (!_settings.TryGetValue(out var settings))
            {
                Debug.LogWarning($"Missing '{nameof(_settings)}'.", this);
                settings = NullVerticalSlotSettings.Instance;
            }

            return new VerticalSlot(
                anchor,
                slideLength,
                settings.CanRotate,
                settings.PresetAngles);
        }
    }
}