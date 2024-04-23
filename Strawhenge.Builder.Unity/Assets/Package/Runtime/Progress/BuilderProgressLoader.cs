using Strawhenge.Builder.Unity.Blueprints;
using ILogger = Strawhenge.Common.Logging.ILogger;

namespace Strawhenge.Builder.Unity
{
    public class BuilderProgressLoader
    {
        readonly IBlueprintRepository _blueprintRepository;
        readonly IBlueprintFactory _blueprintFactory;
        readonly ILogger _logger;

        public BuilderProgressLoader(
            IBlueprintRepository blueprintRepository,
            IBlueprintFactory blueprintFactory,
            ILogger logger)
        {
            _blueprintRepository = blueprintRepository;
            _blueprintFactory = blueprintFactory;
            _logger = logger;
        }

        public void Load(BuilderProgressData data)
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

                var buildItem = _blueprintFactory.Create(blueprint).BuildItem;

                buildItem
                    .Arrange()
                    .PlaceAt(buildItemData.Position, buildItemData.Rotation);
                buildItem.PlaceFinal();
            }
        }
    }
}