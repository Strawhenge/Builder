using Strawhenge.Builder.Unity.BuildItems.Snapping;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class NullArrangeBuildItem : IArrangeBuildItem
    {
#pragma warning disable 67
        public event Action ClippingChanged;
#pragma warning restore 67

        public Vector3 Position { get; } = Vector3.zero;

        public Quaternion Rotation { get; } = new Quaternion();

        public bool ClippingDisabled => false;

        public void Enable()
        {
        }

        public void Disable()
        {
        }

        public IEnumerable<HorizontalSnap> GetAvailableHorizontalSnaps() => Enumerable.Empty<HorizontalSnap>();

        public void ClippingOn()
        {
        }

        public void ClippingOff()
        {
        }

        public IEnumerable<VerticalSnap> GetAvailableVerticalSnaps() => Enumerable.Empty<VerticalSnap>();

        public void Move(Vector3 velocity)
        {
        }

        public void Turn(float amount)
        {
        }
    }
}