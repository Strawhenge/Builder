using System;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public interface IBuildItemController
    {
        void Off();

        void On(
            IBuildItem buildItem,
            Func<bool> canPlaceItem = null,
            Action onPlacedItem = null,
            Action onCancelled = null);

        void On(
            IExistingBuildItem buildItem,
            Action onPlacedItem = null,
            Action onScrapped = null,
            Action onCancelled = null);
    }
}