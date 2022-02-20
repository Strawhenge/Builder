using Strawhenge.Builder.Unity.Monobehaviours;
using UnityEngine;

namespace Strawhenge.Builder.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/BuildItem")]
    public class BuildItemScriptableObject : ScriptableObject
    {
        public BuildItemScript PreviewItem;
        public GameObject FinalItem;       
    }
}