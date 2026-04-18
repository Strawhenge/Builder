using System.Collections.Generic;
using System.Linq;

namespace Strawhenge.Builder.Unity.Progress
{
    public class BuilderProgressData
    {
        public BuilderProgressData(IEnumerable<BuildItemData> buildItems)
        {
            BuildItems = buildItems.ToArray();
        }

        public BuildItemData[] BuildItems { get; }
    }
}