using FunctionalUtilities;
using Strawhenge.Builder.Unity.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class BlueprintRepository : IBlueprintRepository
    {
        readonly BlueprintScriptableObject[] _scriptableObjects;

        public BlueprintRepository(ISettings settings)
        {
            _scriptableObjects = Resources
                .LoadAll<BlueprintScriptableObject>(path: settings.BlueprintsScriptableObjectsPath)
                .ToArray();
        }

        public Maybe<BlueprintScriptableObject> FindByName(string name)
        {
            return _scriptableObjects.FirstOrNone(x =>
                x.name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public IReadOnlyList<BlueprintScriptableObject> GetAll()
        {
            return _scriptableObjects.ToArray();
        }
    }
}