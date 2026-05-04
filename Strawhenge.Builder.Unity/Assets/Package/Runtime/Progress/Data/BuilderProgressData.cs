using System;
using System.Collections.Generic;
using System.Linq;

namespace Strawhenge.Builder.Unity.Progress.Data
{
    public class BuilderProgressData : IBuilderProgressData
    {
        public static BuilderProgressData Empty { get; } = new(Array.Empty<IBuildItemData>());

        public BuilderProgressData(IEnumerable<IBuildItemData> buildItems)
        {
            BuildItems = buildItems.ToArray();
        }

        public IReadOnlyList<IBuildItemData> BuildItems { get; }
    }
}