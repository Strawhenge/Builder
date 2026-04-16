using FunctionalUtilities;
using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity.Data;
using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Common;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/Blueprint")]
    public class BlueprintScriptableObject : ScriptableObject, IBlueprint
    {
        [SerializeField] BuildItemScript _buildItem;
        [SerializeField] SerializableComponentQuantity[] _recipe;
        [SerializeField, Tooltip("Optional")] CategoryScriptableObject _category;

        public BuildItemScript BuildItem => _buildItem;

        public IReadOnlyList<SerializableComponentQuantity> Recipe =>
            _recipe.ExcludeNull().ToArray();

        public string Name => name;

        public Maybe<ICategory> Category => _category == null
            ? Maybe.None<ICategory>()
            : Maybe.Some<ICategory>(_category);
    }
}