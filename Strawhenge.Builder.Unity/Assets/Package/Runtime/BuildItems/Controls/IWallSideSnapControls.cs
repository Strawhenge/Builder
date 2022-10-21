using Strawhenge.Builder.Unity.BuildItems.Snapping;
using System;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public interface IWallSideSnapControls
    {
        event Action Place;
        event Action Release;

        void ControlOn(WallSideSnap snap);

        void ControlOff();
    }
}