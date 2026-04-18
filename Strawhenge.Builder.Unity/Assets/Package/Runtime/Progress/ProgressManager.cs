using Strawhenge.Common.Logging;

namespace Strawhenge.Builder.Unity.Progress
{
    public class ProgressManager
    {
        readonly BuilderProgressTracker _progressTracker;
        readonly BuilderProgressLoader _progressLoader;

        internal ProgressManager(
            IBlueprintRepository blueprintRepository,
            BlueprintFactory blueprintFactory,
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