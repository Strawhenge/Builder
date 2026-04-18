using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.Progress
{
    public interface IBuilderProgressData
    {
        IReadOnlyList<IBuildItemData> BuildItems { get; }
    }
}