using System.Collections.Generic;
using System.Linq;

namespace Strawhenge.Builder.Unity.Progress.Data
{
    public class BuilderProgressData : IBuilderProgressData
    {
        public BuilderProgressData(IEnumerable<BuildItemData> buildItems)
        {
            BuildItems = buildItems.ToArray();
        }

        public IReadOnlyList<IBuildItemData> BuildItems { get; }
    }
}