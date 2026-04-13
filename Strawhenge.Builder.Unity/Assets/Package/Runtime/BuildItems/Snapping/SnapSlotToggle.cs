using Strawhenge.Builder.Unity.BuildItems.Snapping;
using Strawhenge.Builder.Unity.Monobehaviours;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    class SnapSlotToggle
    {
        readonly GameObject[] _snapPoints;
        readonly GameObject[] _slotPoints;

        public SnapSlotToggle(
            IEnumerable<BaseSnapScript<VerticalSnap>> verticalSnapPoints,
            IEnumerable<BaseSnapScript<HorizontalSnap>> horizontalSnapPoints,
            IEnumerable<BaseSlotScript> slotPoints)
        {
            _snapPoints = verticalSnapPoints
                .Select(x => x.gameObject)
                .Concat(horizontalSnapPoints.Select(x => x.gameObject))
                .ToArray();

            _slotPoints = slotPoints.Select(x => x.gameObject).ToArray();
        }

        public void Snaps()
        {
            foreach (var slotPoint in _slotPoints)
                slotPoint.SetActive(false);

            foreach (var snapPoint in _snapPoints)
                snapPoint.SetActive(true);
        }

        public void Slots()
        {
            foreach (var snapPoint in _snapPoints)
                snapPoint.SetActive(false);

            foreach (var slotPoint in _slotPoints)
                slotPoint.SetActive(true);
        }
    }
}