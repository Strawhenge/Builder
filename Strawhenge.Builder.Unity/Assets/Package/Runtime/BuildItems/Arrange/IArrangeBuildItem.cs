using Strawhenge.Builder.Unity.BuildItems.Snapping;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public interface IArrangeBuildItem
    {
        event Action ClippingChanged;


        Vector3 Position { get; }

        Quaternion Rotation { get; }

        bool ClippingDisabled { get; }

        void Enable();

        void Disable();

        Transform GetTransform();

        void Move(Vector3 velocity);

        void Turn(float amount);

        IEnumerable<VerticalSnap> GetAvailableVerticalSnaps();

        IEnumerable<HorizontalSnap> GetAvailableHorizontalSnaps();

        void ClippingOn();

        void ClippingOff();
    }
}