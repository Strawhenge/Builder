using Strawhenge.Builder.Unity.BuildItems.Controller;
using Strawhenge.Builder.Unity.UI.Recipe;
using System;

namespace Strawhenge.Builder.Unity.BuildItems.New
{
    class NewBuildableItemManager
    {
        readonly ComponentInventory _componentInventory;
        readonly BuildItemController _buildItemController;
        readonly IRecipeUI _recipeUI;

        NewBuildableItem _currentNewBuildableItem;

        public NewBuildableItemManager(
            ComponentInventory componentInventory,
            BuildItemController buildItemController,
            IRecipeUI recipeUI)
        {
            _componentInventory = componentInventory;
            _buildItemController = buildItemController;
            _recipeUI = recipeUI;
        }

        public void Set(NewBuildableItem newBuildableItem, Action callback = null)
        {
            _currentNewBuildableItem = newBuildableItem;

            ArrangeCurrentBlueprintBuildItem(callback);
        }

        public void Unset()
        {
            _recipeUI.Hide();
            _buildItemController.Off();

            _currentNewBuildableItem = null;
        }

        void ArrangeCurrentBlueprintBuildItem(Action callback)
        {
            UpdateRecipeUI();

            _buildItemController.On(
                _currentNewBuildableItem.BuildItem,
                () => _currentNewBuildableItem.Recipe.HasRequiredComponents(_componentInventory),
                () =>
                {
                    _currentNewBuildableItem.Recipe.DeductRequiredComponents(_componentInventory);

                    ArrangeCurrentBlueprintBuildItem(callback);
                },
                () =>
                {
                    _recipeUI.Hide();
                    _currentNewBuildableItem = null;
                    callback?.Invoke();
                });
        }

        void UpdateRecipeUI()
        {
            var requirements = _currentNewBuildableItem.Recipe.GetRequirements(_componentInventory);

            _recipeUI.Show(_currentNewBuildableItem.Identifier, requirements);
        }
    }
}