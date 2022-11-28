using Strawhenge.Builder.Unity.Blueprints;
using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Common.Logging;
using System.Linq;

namespace Strawhenge.Builder.Unity
{
    public class BlueprintFactory : IBlueprintFactory
    {
        readonly IDefaultPositionAccessor _initialPositionAccessor;
        readonly ILogger _logger;

        public BlueprintFactory(
            IDefaultPositionAccessor initialPositionAccessor,
            ILogger logger)
        {
            _initialPositionAccessor = initialPositionAccessor;
            _logger = logger;
        }

        public ExistingBlueprint Create(BuildItemScript buildItemScript)
        {
            var buildItem = new ExistingBuildItem(buildItemScript);
            var scrapValue = buildItemScript.ScrapValue;

            return new ExistingBlueprint(buildItemScript.name, buildItem, scrapValue);
        }

        public Blueprint Create(BlueprintScriptableObject scriptableObject)
        {
            var buildItem = CreateBuildItem(scriptableObject);
            var recipe = CreateRecipe(scriptableObject);

            return new Blueprint(scriptableObject.name, buildItem, recipe);
        }

        IBuildItem CreateBuildItem(BlueprintScriptableObject scriptableObject)
        {
            if (scriptableObject.BuildItem == null)
            {
                _logger.LogError($"Missing build item on '{scriptableObject.name}'.");
                return new NullBuildItem();
            }

            return new NewBuildItem(_initialPositionAccessor, scriptableObject.BuildItem);
        }

        static Recipe CreateRecipe(BlueprintScriptableObject scriptableObject)
        {
            var recipeComponents = scriptableObject.Recipe
                .Select(x => new ComponentQuantity(
                    component: new Component(x.Component.Identifier),
                    quantity: x.Quantity));

            return new Recipe(recipeComponents);
        }
    }
}