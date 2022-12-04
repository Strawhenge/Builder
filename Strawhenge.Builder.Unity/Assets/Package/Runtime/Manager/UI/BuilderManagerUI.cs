using Strawhenge.Common.Logging;
using System;

namespace Strawhenge.Builder.Unity.Manager.UI
{
    public class BuilderManagerUI : IBuilderManagerUI
    {
        readonly ILogger _logger;
        BuilderManagerUIScript _script;

        public BuilderManagerUI(ILogger logger)
        {
            _logger = logger;
        }

        public event Action ExitBuilder;
        public event Action OpenMenu;

        public void Setup(BuilderManagerUIScript script)
        {
            _script = script;
            _script.OpenMenu = () => OpenMenu?.Invoke();
            _script.Exit = () => ExitBuilder?.Invoke();
        }

        public void Enable()
        {
            if (_script == null)
            {
                _logger.LogError($"{nameof(BuilderManagerUIScript)} is missing.");
                return;
            }

            _script.Show();
        }

        public void Disable()
        {
            if (_script == null)
            {
                _logger.LogError($"{nameof(BuilderManagerUIScript)} is missing.");
                return;
            }

            _script.Hide();
        }
    }
}