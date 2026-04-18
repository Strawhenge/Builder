using System.Collections.Generic;
using System.Linq;

namespace Strawhenge.Builder.Unity.Progress
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