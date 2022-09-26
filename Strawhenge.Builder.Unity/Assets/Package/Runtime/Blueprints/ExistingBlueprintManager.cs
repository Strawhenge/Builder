using Strawhenge.Builder.Unity.BuildItems;

namespace Strawhenge.Builder.Unity
{
    public class ExistingBlueprintManager
    {
        readonly IComponentInventory _componentInventory;
        readonly IBuildItemController _buildItemController;

        ExistingBlueprint _currentBlueprint;

        public ExistingBlueprintManager(
            IComponentInventory componentInventory,
            IBuildItemController buildItemController)
        {
            _componentInventory = componentInventory;
            _buildItemController = buildItemController;
        }

        public void Set(ExistingBlueprint blueprint)
        {
            _currentBlueprint = blueprint;

            _buildItemController.PreviewOn(
                blueprint.BuildItem,
                onPlacedFinalItem: () => _currentBlueprint = null,
                onCancelled: () => _currentBlueprint = null);
        }

        public void Unset()
        {
            if (_currentBlueprint == null)
                return;

            _buildItemController.PreviewOff();
            _currentBlueprint = null;
        }

        public void Scrap()
        {
            if (_currentBlueprint == null)
                return;

            _currentBlueprint.BuildItem.Scrap();
            _buildItemController.PreviewOff();
            _currentBlueprint.ScrapValue.AddComponentsTo(_componentInventory);
            _currentBlueprint = null;
        }
    }
}