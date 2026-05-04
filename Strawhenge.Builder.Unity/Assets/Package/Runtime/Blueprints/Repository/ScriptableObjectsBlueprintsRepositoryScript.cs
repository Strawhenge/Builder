using FunctionalUtilities;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Blueprints.Repository
{
    public class ScriptableObjectsBlueprintsRepositoryScript : BlueprintsRepositoryScript, IBlueprintRepository
    {
        [SerializeField] BlueprintScriptableObject[] _blueprints;

        readonly Dictionary<string, BlueprintScriptableObject> _blueprintsByName = new();

        void Awake()
        {
            foreach (var blueprint in _blueprints)
                _blueprintsByName[blueprint.name] = blueprint;
        }

        public override Maybe<IBlueprint> FindByName(string name) =>
            _blueprintsByName
                .MaybeGetValue(name)
                .Map<IBlueprint>(blueprint => blueprint);

        public override IReadOnlyList<IBlueprint> GetAll() =>
            _blueprintsByName.Values.ToArray();
    }
}