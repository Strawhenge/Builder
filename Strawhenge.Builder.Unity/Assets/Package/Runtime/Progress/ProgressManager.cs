using Strawhenge.Builder.Unity.Blueprints.Repository;
using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.Progress.Data;
using Strawhenge.Common.Logging;

namespace Strawhenge.Builder.Unity.Progress
{
    public class ProgressManager
    {
        readonly BuilderProgressTracker _progressTracker;
        readonly BuilderProgressLoader _progressLoader;

        internal ProgressManager(
            IBlueprintRepository blueprintRepository,
            BuildableItemFactory buildableItemFactory,
            BuilderProgressTracker progressTracker,
            ILogger logger)
        {
            _progressTracker = progressTracker;
            _progressLoader = new BuilderProgressLoader(blueprintRepository, buildableItemFactory, logger);
        }

        public void Import(IBuilderProgressData data) => _progressLoader.Load(data);

        public IBuilderProgressData Export() => _progressTracker.GetCurrentProgress();
    }
}