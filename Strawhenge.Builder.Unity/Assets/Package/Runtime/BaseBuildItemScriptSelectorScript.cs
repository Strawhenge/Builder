using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public abstract class BaseBuildItemScriptSelectorScript : MonoBehaviour
    {
        public abstract IBuildItemScriptSelector BuildItemScriptSelector { get; }
    }
}