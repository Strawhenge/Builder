using Strawhenge.Builder.Unity.Blueprints.Repository;
using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.Progress.Data;
using ILogger = Strawhenge.Common.Logging.ILogger;

namespace Strawhenge.Builder.Unity.Progress
{
    class BuilderProgressLoader
    {
        readonly IBlueprintRepository _blueprintRepository;
        readonly BuildableItemFactory _buildableItemFactory;
        readonly ILogger _logger;

        public BuilderProgressLoader(
            IBlueprintRepository blueprintRepository,
            BuildableItemFactory buildableItemFactory,
            ILogger logger)
        {
            _blueprintRepository = blueprintRepository;
            _buildableItemFactory = buildableItemFactory;
            _logger = logger;
        }

        public void Load(IBuilderProgressData data)
        {
            _logger.LogInformation("Loading build progress.");

            foreach (var buildItemData in data.BuildItems)
            {
                var maybeBlueprint = _blueprintRepository.FindByName(buildItemData.Name);

                if (!maybeBlueprint.HasSome(out var blueprint))
                {
                    _logger.LogWarning($"Blueprint '{buildItemData.Name}' not found.");
                    continue;
                }

                var buildItem = _buildableItemFactory.Create(blueprint).BuildItem;

                buildItem
                    .Arrange()
                    .PlaceAt(buildItemData.Position, buildItemData.Rotation);
                buildItem.PlaceFinal();
            }
        }
    }
}