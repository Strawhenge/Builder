using Strawhenge.Builder.Unity.BuildItems.Snapping;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class NullBuildItemPreview : IBuildItemPreview
    {
        public Vector3 Position { get; }

        public Quaternion Rotation { get; }

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