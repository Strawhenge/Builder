using Strawhenge.Builder.Unity.Blueprints;
using Strawhenge.Common.Logging;

namespace Strawhenge.Builder.Unity.Progress
{
    class ProgressManager
    {
        readonly BuilderProgressTracker _progressTracker;
        readonly BuilderProgressLoader _progressLoader;

        public ProgressManager(
            IBlueprintRepository blueprintRepository,
            IBlueprintFactory blueprintFactory,
            BuilderProgressTracker progressTracker,
            ILogger logger)
        {
            _progressTracker = progressTracker;
            _progressLoader = new BuilderProgressLoader(blueprintRepository, blueprintFactory, logger);
        }

        public void Import(BuilderProgressData data) => _progressLoader.Load(data);

        public BuilderProgressData Export() => _progressTracker.GetCurrentProgress();
    }
}