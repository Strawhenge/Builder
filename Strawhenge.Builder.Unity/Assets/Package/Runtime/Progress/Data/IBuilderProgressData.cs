using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.Progress.Data
{
    public interface IBuilderProgressData
    {
        IReadOnlyList<IBuildItemData> BuildItems { get; }
    }
}