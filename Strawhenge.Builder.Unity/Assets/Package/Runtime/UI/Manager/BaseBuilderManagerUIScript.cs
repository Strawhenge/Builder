using UnityEngine;

namespace Strawhenge.Builder.Unity.Manager.UI
{
    public abstract class BaseBuilderManagerUIScript : MonoBehaviour
    {
        public abstract IBuilderManagerUI BuilderManagerUI { get; }
    }
}