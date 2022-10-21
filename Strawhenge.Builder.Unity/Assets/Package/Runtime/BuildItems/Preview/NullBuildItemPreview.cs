using Strawhenge.Builder.Unity.BuildItems.Snapping;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class NullBuildItemPreview : IBuildItemPreview
    {
        public Vector3 Position { get; } = Vector3.zero;

        public Quaternion Rotation { get; } = new Quaternion();

        public IEnumerable<FloorEdgeSnap> GetAvailableHorizontalSnaps() => Enumerable.Empty<FloorEdgeSnap>();

        public IEnumerable<WallSideSnap> GetAvailableVerticalSnaps() => Enumerable.Empty<WallSideSnap>();

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