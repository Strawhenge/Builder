using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    class SnapSlotToggle
    {
        readonly GameObject[] _snapPoints;
        readonly GameObject[] _slotPoints;

        public SnapSlotToggle(
            IEnumerable<VerticalSnapScript> verticalSnapPoints,
            IEnumerable<HorizontalSnapScript> horizontalSnapPoints,
            IEnumerable<VerticalSlotScript> verticalSlotPoints,
            IEnumerable<HorizontalSlotScript> horizontalSlotPoints)
        {
            _snapPoints = verticalSnapPoints
                .Select(x => x.gameObject)
                .Concat(horizontalSnapPoints.Select(x => x.gameObject))
                .ToArray();

            _slotPoints = verticalSlotPoints
                .Select(x => x.gameObject)
                .Concat(horizontalSlotPoints.Select(x => x.gameObject))
                .ToArray();
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