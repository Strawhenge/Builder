using Strawhenge.Builder.Unity.BuildItems.Snapping;
using System;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public interface IFloorEdgeSnapControls
    {
        event Action Place;
        event Action Release;

        void ControlOn(FloorEdgeSnap snap);

        void ControlOff();
    }
}