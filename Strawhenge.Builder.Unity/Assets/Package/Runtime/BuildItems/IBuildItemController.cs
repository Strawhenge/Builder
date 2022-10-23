﻿using System;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public interface IBuildItemController
    {
        void Off();

        void On(
            IBuildItem buildItem,
            Func<bool> canPlaceFinalItem = null,
            Action onPlacedFinalItem = null,
            Action onCancelled = null);
    }
}