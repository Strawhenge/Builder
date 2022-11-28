using Strawhenge.Builder.Unity.BuildItems.Snapping;
using System;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public interface IVerticalSnapControls
    {
        event Action Place;
        event Action Release;
        event Action Cancel;

        void ControlOn(VerticalSnap snap);

        void ControlOff();
    }
}