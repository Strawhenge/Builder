using Strawhenge.Builder.Unity.BuildItems.Snapping;
using Strawhenge.Common.Ranges;
using Strawhenge.Common.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class ArrangeBuildItem : IArrangeBuildItem
    {
        readonly Transform _transform;
        readonly ArrangeBuildItemScript _script;
        readonly FloatRange _tiltRange;
        readonly Func<IEnumerable<VerticalSnap>> _getAvailableVerticalSnaps;
        readonly Func<IEnumerable<HorizontalSnap>> _getAvailableHorizontalSnaps;

        float _turnAngle;
        float _tiltAngle;

        public ArrangeBuildItem(
            Transform transform,
            FloatRange tiltRange,
            Func<IEnumerable<VerticalSnap>> getAvailableVerticalSnaps,
            Func<IEnumerable<HorizontalSnap>> getAvailableHorizontalSnaps)
        {
            _transform = transform;
            _script = transform.GetOrAddComponent<ArrangeBuildItemScript>();
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

        public void Move(Vector3 velocity) => _script.Move(velocity);

        public void Turn(float amount) => _script.Turn(amount);

        public void Tilt(float amount)
        {
        }
    }
}