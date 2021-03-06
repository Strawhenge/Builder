using Strawhenge.Builder.Unity.BuildItems.Snapping;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public interface IBuildItemPreview
    {
        Vector3 Position { get; }

        Quaternion Rotation { get; }

        void Move(Vector3 velocity);

        void Turn(float amount);

        void Tilt(float amount);

        IEnumerable<VerticalSnap> GetAvailableVerticalSnaps();

        IEnumerable<HorizontalSnap> GetAvailableHorizontalSnaps();
    }
}