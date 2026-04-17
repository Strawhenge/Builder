using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.UI;
using System;

namespace Strawhenge.Builder.Unity
{
    public class BlueprintManager
    {
        readonly ComponentInventory _componentInventory;
        readonly BuildItemController _buildItemController;
        readonly IRecipeUI _recipeUI;

        Blueprint _currentBlueprint;

        public BlueprintManager(
            ComponentInventory componentInventory,
            BuildItemController buildItemController,
            IRecipeUI recipeUI)
        {
            _componentInventory = componentInventory;
            _buildItemController = buildItemController;
            _recipeUI = recipeUI;
        }

        public void Set(Blueprint blueprint, Action callback = null)
        {
            _currentBlueprint = blueprint;

            ArrangeCurrentBlueprintBuildItem(callback);
        }

        public void Unset()
        {
            _recipeUI.Hide();
            _buildItemController.Off();

            _currentBlueprint = null;
        }

        void ArrangeCurrentBlueprintBuildItem(Action callback)
        {
            UpdateRecipeUI();

            _buildItemController.On(
                _currentBlueprint.BuildItem,
                () => _currentBlueprint.Recipe.HasRequiredComponents(_componentInventory),
                () =>
                {
                    _currentBlueprint.Recipe.DeductRequiredComponents(_componentInventory);

                    ArrangeCurrentBlueprintBuildItem(callback);
                },
                () =>
                {
                    _recipeUI.Hide();
                    _currentBlueprint = null;
                    callback?.Invoke();
                });
        }

        void UpdateRecipeUI()
        {
            var requirements = _currentBlueprint.Recipe.GetRequirements(_componentInventory);

            _recipeUI.Show(_currentBlueprint.Identifier, requirements);
        }
    }
}