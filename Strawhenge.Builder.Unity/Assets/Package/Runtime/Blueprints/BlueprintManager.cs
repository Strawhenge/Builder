using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.UI;

namespace Strawhenge.Builder.Unity
{
    public class BlueprintManager
    {
        readonly IComponentInventory _componentInventory;
        readonly IBuildItemController _buildItemController;
        readonly IRecipeUI _recipeUI;

        Blueprint currentBlueprint;

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
            currentBlueprint = blueprint;

            ShowBuildItemPreview();
        }

        public void Unset()
        {
            _recipeUI.Hide();
            _buildItemController.PreviewOff();

            currentBlueprint = null;
        }

        void ShowBuildItemPreview()
        {
            UpdateRecipeUI();

            _buildItemController.PreviewOn(
                currentBlueprint.BuildItem,
                canPlaceFinalItem: () => currentBlueprint.Recipe.HasRequiredComponents(_componentInventory),
                onPlacedFinalItem: () =>
                {
                    currentBlueprint.Recipe.DeductRequiredComponents(_componentInventory);

                    ShowBuildItemPreview();
                },
                onCancelled: () =>
                {
                    _recipeUI.Hide();
                    currentBlueprint = null;
                });
        }

        void UpdateRecipeUI()
        {
            var requirements = currentBlueprint.Recipe.GetRequirements(_componentInventory);

            _recipeUI.Show(currentBlueprint.Identifier, requirements);          
        }
    }
}