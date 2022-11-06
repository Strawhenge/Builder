using Strawhenge.Builder.Unity.BuildItems.Snapping;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public interface IArrangeBuildItem
    {
        Vector3 Position { get; }

        Quaternion Rotation { get; }

        void Enable();

        void Disable();

        void Move(Vector3 velocity);

        void Turn(float amount);

        IEnumerable<VerticalSnap> GetAvailableVerticalSnaps();

        IEnumerable<HorizontalSnap> GetAvailableHorizontalSnaps();
    }
}