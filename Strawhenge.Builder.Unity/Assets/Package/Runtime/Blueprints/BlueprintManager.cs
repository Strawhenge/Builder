using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.UI;
using System;

namespace Strawhenge.Builder.Unity
{
    public class BlueprintManager
    {
        readonly IComponentInventory _componentInventory;
        readonly IBuildItemController _buildItemController;
        readonly IRecipeUI _recipeUI;

        Blueprint _currentBlueprint;

        public BlueprintManager(
            IComponentInventory componentInventory,
            IBuildItemController buildItemController,
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
                canPlaceItem: () => _currentBlueprint.Recipe.HasRequiredComponents(_componentInventory),
                onPlacedItem: () =>
                {
                    _currentBlueprint.Recipe.DeductRequiredComponents(_componentInventory);

                    ArrangeCurrentBlueprintBuildItem(callback);
                },
                onCancelled: () =>
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