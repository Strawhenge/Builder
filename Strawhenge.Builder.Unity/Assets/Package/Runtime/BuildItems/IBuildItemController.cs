using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public interface IBuildItemController
    {
        Maybe<IBuildItemPreview> CurrentPreview { get; }

        void PreviewOff();

        void PreviewOn(IBuildItem buildItem, Func<bool> canPlaceFinalItem = null, Action onPlacedFinalItem = null, Action onCancelled = null);

        void SpawnFinalItem();
    }
}