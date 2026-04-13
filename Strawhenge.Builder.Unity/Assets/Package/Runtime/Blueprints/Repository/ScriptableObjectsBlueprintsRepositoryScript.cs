using FunctionalUtilities;
using Strawhenge.Builder.Unity.ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Package.Runtime.Blueprints
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

        public override Maybe<BlueprintScriptableObject> FindByName(string name) =>
            _blueprintsByName.MaybeGetValue(name);

        public override IReadOnlyList<BlueprintScriptableObject> GetAll() =>
            _blueprintsByName.Values.ToArray();
    }
}