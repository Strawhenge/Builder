using FunctionalUtilities;
using Strawhenge.Builder.Menu;
using UnityEngine;

namespace Strawhenge.Builder.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/Category")]
    public class CategoryScriptableObject : ScriptableObject, ICategory
    {
        [SerializeField, Tooltip("Optional")]
        CategoryScriptableObject _parent;

        string ICategory.Name => name;

        Maybe<ICategory> ICategory.Parent => _parent == null
            ? Maybe.None<ICategory>()
            : Maybe.Some<ICategory>(_parent);
    }
}
