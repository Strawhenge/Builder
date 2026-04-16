using FunctionalUtilities;
using Strawhenge.Builder.Unity.Package.Runtime.Blueprints;
using Strawhenge.Builder.Unity.ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class ResourcesBlueprintRepositoryScript : BlueprintsRepositoryScript
    {
        [SerializeField] string _path = "Assets/Resources";

        readonly Dictionary<string, BlueprintScriptableObject> _blueprintsByName = new();

        void Awake()
        {
            var blueprints = Resources
                .LoadAll<BlueprintScriptableObject>(_path)
                .ToArray();

            foreach (var blueprint in blueprints)
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