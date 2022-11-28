using Strawhenge.Builder.Unity.BuildItems.Snapping;
using System;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public interface IHorizontalSnapControls
    {
        event Action Place;
        event Action Release;
        event Action Cancel;

        void ControlOn(HorizontalSnap snap);

        void ControlOff();
    }
}