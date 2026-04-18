using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Builder.Unity.Progress;
using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Common.Logging;
using System.Linq;

namespace Strawhenge.Builder.Unity
{
    class BuildableItemFactory
    {
        readonly BuilderProgressTracker _builderProgressTracker;
        readonly IDefaultPositionAccessor _initialPositionAccessor;
        readonly ILogger _logger;

        public BuildableItemFactory(
            BuilderProgressTracker builderProgressTracker,
            IDefaultPositionAccessor initialPositionAccessor,
            ILogger logger)
        {
            _builderProgressTracker = builderProgressTracker;
            _initialPositionAccessor = initialPositionAccessor;
            _logger = logger;
        }

        public ExistingBuildableItem Create(BuildItemScript buildItemScript)
        {
            var buildItem = new ExistingBuildItem(_builderProgressTracker, buildItemScript);
            var scrapValue = buildItemScript.ScrapValue;

            return new ExistingBuildableItem(buildItemScript.name, buildItem, scrapValue);
        }

        public NewBuildableItem Create(IBlueprint scriptableObject)
        {
            var buildItem = CreateBuildItem(scriptableObject);
            var recipe = CreateRecipe(scriptableObject);

            return new NewBuildableItem(scriptableObject.Name, buildItem, recipe);
        }

        IBuildItem CreateBuildItem(IBlueprint scriptableObject)
        {
            if (scriptableObject.BuildItem == null)
            {
                _logger.LogError($"Missing build item on '{scriptableObject.Name}'.");
                return new NullBuildItem();
            }

            return new NewBuildItem(
                _builderProgressTracker,
                _initialPositionAccessor,
                scriptableObject.BuildItem,
                scriptableObject.Name);
        }

        static Recipe CreateRecipe(IBlueprint scriptableObject)
        {
            var recipeComponents = scriptableObject.Recipe
                .Select(x => new ComponentQuantity(
                    component: new Component(x.Component.Identifier),
                    quantity: x.Quantity));

            return new Recipe(recipeComponents);
        }
    }
}