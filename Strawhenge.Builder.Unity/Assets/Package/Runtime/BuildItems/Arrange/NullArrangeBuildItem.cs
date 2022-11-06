using Strawhenge.Builder.Unity.BuildItems.Snapping;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class NullArrangeBuildItem : IArrangeBuildItem
    {
        public Vector3 Position { get; } = Vector3.zero;

        public Quaternion Rotation { get; } = new Quaternion();

        public void Enable()
        {
        }

        public void Disable()
        {
        }

        public IEnumerable<HorizontalSnap> GetAvailableHorizontalSnaps() => Enumerable.Empty<HorizontalSnap>();

        public IEnumerable<VerticalSnap> GetAvailableVerticalSnaps() => Enumerable.Empty<VerticalSnap>();

        public void Move(Vector3 velocity)
        {
        }

        public void Tilt(float amount)
        {
        }

        public void Turn(float amount)
        {
        }
    }
}