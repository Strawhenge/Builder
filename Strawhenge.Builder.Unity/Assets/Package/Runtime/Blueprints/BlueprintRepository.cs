using FunctionalUtilities;
using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Common.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Strawhenge.Builder.Unity
{
    public class BlueprintRepository : IBlueprintRepository
    {
        readonly ILogger _logger;

        readonly Dictionary<string, BlueprintScriptableObject> _blueprints =
            new Dictionary<string, BlueprintScriptableObject>();

        public BlueprintRepository(ILogger logger)
        {
            _logger = logger;
        }

        public Maybe<BlueprintScriptableObject> GetByName(string name)
        {
            if (_blueprints.TryGetValue(name, out var blueprint))
                return blueprint;

            return Maybe.None<BlueprintScriptableObject>();
        }

        public IReadOnlyList<BlueprintScriptableObject> GetAll()
        {
            return _blueprints.Values.ToArray();
        }

        public void Add(IEnumerable<BlueprintScriptableObject> blueprints)
        {
            foreach (var blueprint in blueprints)
            {
                if (_blueprints.ContainsKey(blueprint.name))
                {
                    _logger.LogWarning($"Duplicate blueprint '{blueprint.name}'.");
                    continue;
                }

                _blueprints.Add(blueprint.name, blueprint);
            }
        }

        public void Clear()
        {
            _blueprints.Clear();
        }
    }
}