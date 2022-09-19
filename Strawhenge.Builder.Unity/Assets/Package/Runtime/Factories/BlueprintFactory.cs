using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.ScriptableObjects;
using System.Linq;

namespace Strawhenge.Builder.Unity.Factories
{
    public class BlueprintFactory
    {
        private readonly RecipeFactory recipeFactory;
        private readonly ILogger logger;

        public BlueprintFactory(
            RecipeFactory recipeFactory,
            ILogger logger)
        {
            this.recipeFactory = recipeFactory;
            this.logger = logger;
        }

        public Blueprint Create(BlueprintScriptableObject scriptableObject)
        {
            var buildItem = CreateBuildItem(scriptableObject);
            var recipe = CreateRecipe(scriptableObject);

            return new Blueprint(scriptableObject.name, buildItem, recipe);
        }

        private IBuildItem CreateBuildItem(BlueprintScriptableObject scriptableObject)
        {
            if (scriptableObject.BuildItem == null)
            {
                logger.LogError($"Missing build item on '{scriptableObject.name}'.");
                return new NullBuildItem();
            }

            return new BuildItem(scriptableObject.BuildItem);
        }

        private Recipe CreateRecipe(BlueprintScriptableObject scriptableObject)
        {
            var recipeComponents = scriptableObject.Recipe
                .Select(x => new ComponentQuantity(
                    component: new Component(x.Component.Identifier),
                    quantity: x.Quantity));

            return recipeFactory.Create(recipeComponents);
        }
    }
}