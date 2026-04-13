using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public abstract class BaseBuildItemSelectorScript : MonoBehaviour
    {
        public abstract IBuildItemSelector BuildItemSelector { get; }
    }
}