using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public abstract class BuildItemSelectorScript : MonoBehaviour
    {
        public abstract IBuildItemSelector BuildItemSelector { get; }
    }
}