using System;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public interface IBuildItemControls
    {
        event Action PlaceBuildItem;
        event Action Snap;

        void ControlOn(IBuildItemPreview buildItem);

        void ControlOff();
    }
}