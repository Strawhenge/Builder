using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.UI;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class BlueprintManager
    {
        private readonly IComponentInventory componentInventory;
        private readonly IBuildItemController buildItemController;
        private readonly IRecipeUI recipeUI;

        private Blueprint currentBlueprint;

        public BlueprintManager(
            IComponentInventory componentInventory,
            IBuildItemController buildItemController,
            IRecipeUI recipeUI)
        {
            this.componentInventory = componentInventory;
            this.buildItemController = buildItemController;
            this.recipeUI = recipeUI;
        }

        public Maybe<IBuildItemPreview> Preview => buildItemController.CurrentPreview;

        public Vector3 DefaultPosition { get; set; } = Vector3.zero;

        public void Build()
        {
            if (currentBlueprint == null || !currentBlueprint.Recipe.HasRequiredComponents(componentInventory))
                return;

            buildItemController.SpawnFinalItem();
            currentBlueprint.Recipe.DeductRequiredComponents(componentInventory);

            UpdateRecipeUI();
        }

        public void Unset()
        {
            recipeUI.Hide();
            buildItemController.PreviewOff();

            currentBlueprint = null;
        }

        public void Set(Blueprint blueprint)
        {
            currentBlueprint = blueprint;

            ShowBuildItemPreview();
            UpdateRecipeUI();
        }

        private void ShowBuildItemPreview()
        {
            var point = buildItemController.CurrentPreview
                .Map(x => x.Position)
                .Reduce(() => DefaultPosition);

            var rotation = buildItemController.CurrentPreview
                .Map(x => x.Rotation)
                .Reduce(() => new Quaternion());

            buildItemController.PreviewOn(currentBlueprint.BuildItem, point, rotation);
        }

        private void UpdateRecipeUI()
        {
            var requirements = currentBlueprint.Recipe.GetRequirements(componentInventory);

            var uiModel = new RecipeUIModel
            {
                RecipeTitle = currentBlueprint.Identifier,
                Requirements = requirements.Select(x => new RecipeRequirementUIModel
                {
                    ComponentName = x.Component.Identifier,
                    QuantityInInventory = x.QuantityInInventory,
                    QuantityRequired = x.QuantityRequired
                })
            };

            recipeUI.Show(uiModel);
        }
    }
}