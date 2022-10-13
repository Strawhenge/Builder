using System;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public interface IBuildItemControls
    {
        event Action PlaceBuildItem;

        void ControlOn(IBuildItemPreview buildItem);

        void ControlOff();
    }
}