using Strawhenge.Builder.Unity.BuildItems;
using System;

namespace Strawhenge.Builder.Unity.Tests.Fakes
{
    class BuildItemControllerFake : IBuildItemController
    {
        internal bool IsOn { get; private set; }

        public void Off() => IsOn = false;

        public void On(
            IBuildItem buildItem,
            Func<bool> canPlaceItem = null,
            Action onPlacedItem = null,
            Action onCancelled = null) =>
            IsOn = true;
    }
}
