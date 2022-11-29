using System;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public interface IBuildItemControls
    {
        event Action Place;
        event Action Snap;
        event Action Cancel;
        event Action Scrap;

        void ControlOn(IArrangeBuildItem buildItem, bool canScrap);

        void ControlOff();
    }
}