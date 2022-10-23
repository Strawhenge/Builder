using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.UI;

namespace Strawhenge.Builder.Unity
{
    public class ExistingBlueprintManager
    {
        readonly IComponentInventory _componentInventory;
        readonly IBuildItemController _buildItemController;
        readonly IScrapUI _scrapUI;

        ExistingBlueprint _currentBlueprint;

        public ExistingBlueprintManager(
            IComponentInventory componentInventory,
            IBuildItemController buildItemController,
            IScrapUI scrapUI)
        {
            _componentInventory = componentInventory;
            _buildItemController = buildItemController;
            _scrapUI = scrapUI;
        }

        public void Set(ExistingBlueprint blueprint)
        {
            _currentBlueprint = blueprint;

            _buildItemController.On(
                blueprint.BuildItem,
                onPlacedFinalItem: OnBuildItemArrangeEnded,
                onCancelled: OnBuildItemArrangeEnded);

            var additions = blueprint.ScrapValue.GetAdditions(_componentInventory);

            _scrapUI.Show(blueprint.Identifier, additions);
        }

        public void Unset()
        {
            if (_currentBlueprint == null)
                return;

            _buildItemController.Off();
        }

        public void Scrap()
        {
            if (_currentBlueprint == null)
                return;

            _currentBlueprint.BuildItem.Scrap();
            _currentBlueprint.ScrapValue.AddComponentsTo(_componentInventory);
            _buildItemController.Off();
        }

        void OnBuildItemArrangeEnded()
        {
            _currentBlueprint = null;
            _scrapUI.Hide();
        }
    }
}