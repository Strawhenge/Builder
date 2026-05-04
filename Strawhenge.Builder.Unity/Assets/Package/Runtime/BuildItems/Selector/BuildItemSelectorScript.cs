using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Selector
{
    public abstract class BuildItemSelectorScript : MonoBehaviour
    {
        public abstract IBuildItemSelector BuildItemSelector { get; }
    }
}