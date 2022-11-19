﻿using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.UI;

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

        public void Set(Blueprint blueprint)
        {
            _currentBlueprint = blueprint;

            ArrangeCurrentBlueprintBuildItem();
        }

        public void Unset()
        {
            _recipeUI.Hide();
            _buildItemController.Off();

            _currentBlueprint = null;
        }

        void ArrangeCurrentBlueprintBuildItem()
        {
            UpdateRecipeUI();

            _buildItemController.On(
                _currentBlueprint.BuildItem,
                canPlaceItem: () => _currentBlueprint.Recipe.HasRequiredComponents(_componentInventory),
                onPlacedItem: () =>
                {
                    _currentBlueprint.Recipe.DeductRequiredComponents(_componentInventory);

                    ArrangeCurrentBlueprintBuildItem();
                },
                onCancelled: () =>
                {
                    _recipeUI.Hide();
                    _currentBlueprint = null;
                });
        }

        void UpdateRecipeUI()
        {
            var requirements = _currentBlueprint.Recipe.GetRequirements(_componentInventory);

            _recipeUI.Show(_currentBlueprint.Identifier, requirements);          
        }
    }
}