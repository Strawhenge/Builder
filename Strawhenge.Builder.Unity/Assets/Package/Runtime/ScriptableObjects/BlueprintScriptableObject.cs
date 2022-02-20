using Strawhenge.Builder.Unity.Data;
using UnityEngine;

namespace Strawhenge.Builder.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/Blueprint")]
    public class BlueprintScriptableObject : ScriptableObject
    {
        public BuildItemScriptableObject BuildItem;
        public SerializableComponentQuantity[] Recipe;
    }
}