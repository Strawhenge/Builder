using FunctionalUtilities;
using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity.Data;
using Strawhenge.Builder.Unity.Monobehaviours;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/Blueprint")]
    public class BlueprintScriptableObject : ScriptableObject, ICategorizable
    {
        [SerializeField] BuildItemScript _buildItem;
        [SerializeField] SerializableComponentQuantity[] _recipe;
        [SerializeField, Tooltip("Optional")] CategoryScriptableObject _category;

        internal BuildItemScript BuildItem => _buildItem;

        internal IEnumerable<SerializableComponentQuantity> Recipe => _recipe;

        string ICategorizable.Name => name;

        Maybe<ICategory> ICategorizable.Category => _category == null
            ? Maybe.None<ICategory>()
            : Maybe.Some<ICategory>(_category);
    }
}