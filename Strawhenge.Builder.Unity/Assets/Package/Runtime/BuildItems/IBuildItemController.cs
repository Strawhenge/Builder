using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public interface IBuildItemController
    {
        Maybe<IBuildItemPreview> CurrentPreview { get; }

        void PreviewOff();

        void PreviewOn(IBuildItem buildItem);

        void SpawnFinalItem();
    }
}