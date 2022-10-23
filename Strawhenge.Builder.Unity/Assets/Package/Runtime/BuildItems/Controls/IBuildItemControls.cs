using System;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public interface IBuildItemControls
    {
        event Action Place;
        event Action Snap;

        void ControlOn(IArrangeBuildItem buildItem);

        void ControlOff();
    }
}