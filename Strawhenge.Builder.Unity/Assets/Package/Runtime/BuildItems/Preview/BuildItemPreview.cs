using Strawhenge.Builder.Unity.BuildItems.Snapping;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class BuildItemPreview : IBuildItemPreview
    {
        readonly Transform transform;
        readonly FloatRange tiltRange;
        readonly Func<IEnumerable<VerticalSnap>> getAvailableVerticalSnaps;
        readonly Func<IEnumerable<HorizontalSnap>> getAvailableHorizontalSnaps;

        float turnAngle;
        float tiltAngle;

        public BuildItemPreview(
            Transform transform,
            FloatRange tiltRange,
            Func<IEnumerable<VerticalSnap>> getAvailableVerticalSnaps,
            Func<IEnumerable<HorizontalSnap>> getAvailableHorizontalSnaps)
        {
            this.transform = transform;
            this.tiltRange = tiltRange;
            this.getAvailableVerticalSnaps = getAvailableVerticalSnaps;
            this.getAvailableHorizontalSnaps = getAvailableHorizontalSnaps;
        }

        public Vector3 Position => transform.position;

        public Quaternion Rotation => transform.rotation;

        public IEnumerable<VerticalSnap> GetAvailableVerticalSnaps() =>
            getAvailableVerticalSnaps().ToArray();

        public IEnumerable<HorizontalSnap> GetAvailableHorizontalSnaps() =>
            getAvailableHorizontalSnaps().ToArray();

        public void Move(Vector3 velocity)
        {
            transform.position += velocity;
        }

        public void Turn(float amount)
        {
            turnAngle += amount;
            UpdateRotation();
        }

        public void Tilt(float amount)
        {
            tiltAngle = tiltRange.Clamp(tiltAngle + amount);
            UpdateRotation();
        }

        void UpdateRotation()
        {
            transform.rotation = Quaternion.AngleAxis(turnAngle, Vector3.up) * Quaternion.AngleAxis(tiltAngle, Vector3.right);
        }
    }
}