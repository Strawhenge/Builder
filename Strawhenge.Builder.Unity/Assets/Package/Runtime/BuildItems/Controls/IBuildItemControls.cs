using System;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public interface IBuildItemControls
    {
        event Action Place;
        event Action Snap;
        event Action Cancel;

        void ControlOn(IArrangeBuildItem buildItem);

        void ControlOff();
    }
}