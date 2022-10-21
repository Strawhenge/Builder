using Strawhenge.Builder.Unity.BuildItems.Snapping;
using Strawhenge.Common.Ranges;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class BuildItemPreview : IBuildItemPreview
    {
        readonly Transform _transform;
        readonly FloatRange _tiltRange;
        readonly Func<IEnumerable<VerticalSnap>> _getAvailableVerticalSnaps;
        readonly Func<IEnumerable<HorizontalSnap>> _getAvailableHorizontalSnaps;

        float _turnAngle;
        float _tiltAngle;

        public BuildItemPreview(
            Transform transform,
            FloatRange tiltRange,
            Func<IEnumerable<VerticalSnap>> getAvailableVerticalSnaps,
            Func<IEnumerable<HorizontalSnap>> getAvailableHorizontalSnaps)
        {
            _transform = transform;
            _tiltRange = tiltRange;
            _getAvailableVerticalSnaps = getAvailableVerticalSnaps;
            _getAvailableHorizontalSnaps = getAvailableHorizontalSnaps;
        }

        public Vector3 Position => _transform.position;

        public Quaternion Rotation => _transform.rotation;

        public IEnumerable<VerticalSnap> GetAvailableVerticalSnaps() =>
            _getAvailableVerticalSnaps().ToArray();

        public IEnumerable<HorizontalSnap> GetAvailableHorizontalSnaps() =>
            _getAvailableHorizontalSnaps().ToArray();

        public void Move(Vector3 velocity)
        {
            _transform.position += velocity;
        }

        public void Turn(float amount)
        {
            _turnAngle += amount;
            UpdateRotation();
        }

        public void Tilt(float amount)
        {
            _tiltAngle = _tiltRange.Clamp(_tiltAngle + amount);
            UpdateRotation();
        }

        void UpdateRotation()
        {
            _transform.rotation = Quaternion.AngleAxis(_turnAngle, Vector3.up) *
                                  Quaternion.AngleAxis(_tiltAngle, Vector3.right);
        }
    }
}