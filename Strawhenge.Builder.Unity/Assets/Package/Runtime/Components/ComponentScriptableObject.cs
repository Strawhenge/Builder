using UnityEngine;

namespace Strawhenge.Builder.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/Component")]
    public class ComponentScriptableObject : ScriptableObject
    {
        public string Identifier => name;
    }
}