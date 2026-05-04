using Strawhenge.Builder.Unity.BuildItems.Controller;
using Strawhenge.Builder.Unity.UI.Scrap;
using System;

namespace Strawhenge.Builder.Unity.BuildItems.Existing
{
    class ExistingBuildableItemManager
    {
        readonly ComponentInventory _componentInventory;
        readonly BuildItemController _buildItemController;
        readonly IScrapUI _scrapUI;

        ExistingBuildableItem _currentBuildableItem;

        public ExistingBuildableItemManager(
            ComponentInventory componentInventory,
            BuildItemController buildItemController,
            IScrapUI scrapUI)
        {
            _componentInventory = componentInventory;
            _buildItemController = buildItemController;
            _scrapUI = scrapUI;
        }

        public void Set(ExistingBuildableItem buildableItem, Action callback = null)
        {
            _currentBuildableItem = buildableItem;

            _buildItemController.On(
                buildableItem.BuildItem,
                onPlacedItem: () => OnBuildItemArrangeEnded(callback),
                onScrapped: () =>
                {
                    Scrap();
                    OnBuildItemArrangeEnded(callback);
                },
                onCancelled: () => OnBuildItemArrangeEnded(callback));

            var additions = buildableItem.ScrapValue.GetAdditions(_componentInventory);

            _scrapUI.Show(buildableItem.Identifier, additions);
        }

        public void Unset()
        {
            if (_currentBuildableItem == null)
                return;

            _buildItemController.Off();
        }

        void Scrap()
        {
            if (_currentBuildableItem == null)
                return;
           
            _currentBuildableItem.ScrapValue.AddComponentsTo(_componentInventory);
            _buildItemController.Off();
        }

        void OnBuildItemArrangeEnded(Action callback = null)
        {
            _currentBuildableItem = null;
            _scrapUI.Hide();

            callback?.Invoke();
        }
    }
}