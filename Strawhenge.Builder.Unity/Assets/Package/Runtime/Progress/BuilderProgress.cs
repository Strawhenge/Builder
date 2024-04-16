using ILogger = Strawhenge.Common.Logging.ILogger;

namespace Strawhenge.Builder.Unity
{
    public class BuilderProgress
    {
        readonly ILogger _logger;

        public BuilderProgress(ILogger logger)
        {
            _logger = logger;
        }

        public void Load(BuilderProgressData data)
        {
            _logger.LogInformation("Loading build progress.");
        }
    }
}