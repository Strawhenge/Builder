using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity.Data;
using UnityEngine;

namespace Strawhenge.Builder.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/Blueprint")]
    public class BlueprintScriptableObject : ScriptableObject, ICategorizable
    {
        public BuildItemScriptableObject BuildItem;
        public SerializableComponentQuantity[] Recipe;

        string ICategorizable.Name => name;

        Maybe<Category> ICategorizable.Category => Maybe.None<Category>();
    }
}