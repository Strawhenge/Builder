using Strawhenge.Builder.Unity.ScriptableObjects;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity
{
    public class BlueprintRepository : IBlueprintRepository
    {
        readonly List<BlueprintScriptableObject> _blueprints = new List<BlueprintScriptableObject>();

        public IReadOnlyList<BlueprintScriptableObject> GetAll()
        {
            return _blueprints.AsReadOnly();
        }

        public void Add(IEnumerable<BlueprintScriptableObject> blueprints)
        {
            _blueprints.AddRange(blueprints);
        }

        public void Clear()
        {
            _blueprints.Clear();
        }
    }
}