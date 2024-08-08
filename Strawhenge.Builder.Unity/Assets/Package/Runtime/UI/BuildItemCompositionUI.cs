using System.Collections.Generic;
using ILogger = Strawhenge.Common.Logging.ILogger;

namespace Strawhenge.Builder.Unity.UI
{
    public class BuildItemCompositionUI : IRecipeUI, IScrapUI
    {
        readonly ILogger _logger;
        BuildItemCompositionUIScript _script;

        public BuildItemCompositionUI(ILogger logger)
        {
            _logger = logger;
        }

        public void Setup(BuildItemCompositionUIScript script)
        {
            _script = script;
            Hide();
        }

        public void Reset()
        {
            _script = null;
        }

        public void Hide()
        {
            if (ReferenceEquals(_script, null))
            {
                _logger.LogError($"{nameof(BuildItemCompositionUIScript)} is missing.");
                return;
            }

            _script.Hide();
        }

        public void Show(string recipeName, IEnumerable<RecipeRequirement> requirements)
        {
            if (ReferenceEquals(_script, null))
            {
                _logger.LogError($"{nameof(BuildItemCompositionUIScript)} is missing.");
                return;
            }

            _script.ShowRecipe(recipeName, requirements);
        }

        public void Show(string scrapName, IEnumerable<ScrapAddition> additions)
        {
            if (ReferenceEquals(_script, null))
            {
                _logger.LogError($"{nameof(BuildItemCompositionUIScript)} is missing.");
                return;
            }

            _script.ShowScrap(scrapName, additions);
        }
    }
}