using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity.Data;
using Strawhenge.Builder.Unity.Monobehaviours;
using UnityEngine;

namespace Strawhenge.Builder.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/Blueprint")]
    public class BlueprintScriptableObject : ScriptableObject, ICategorizable
    {
        public BuildItemScript BuildItem;
        public SerializableComponentQuantity[] Recipe;

        [SerializeField, Tooltip("Optional")]
        CategoryScriptableObject _category;

        string ICategorizable.Name => name;

        Maybe<ICategory> ICategorizable.Category => _category == null
            ? Maybe.None<ICategory>()
            : Maybe.Some<ICategory>(_category);
    }
}