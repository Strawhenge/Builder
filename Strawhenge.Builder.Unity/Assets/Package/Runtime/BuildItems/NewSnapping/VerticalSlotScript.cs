using Strawhenge.Common.Unity.Serialization;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.NewSnapping
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

            var settings = _settings.GetValue(); // TODO Handle missing.

            return new VerticalSlot(
                anchor,
                slideLength,
                settings.CanRotate,
                settings.PresetAngles);
        }
    }
}