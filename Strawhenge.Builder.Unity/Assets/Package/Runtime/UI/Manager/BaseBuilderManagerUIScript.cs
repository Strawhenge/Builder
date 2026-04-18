using UnityEngine;

namespace Strawhenge.Builder.Unity.UI.Manager
{
    public abstract class BaseBuilderManagerUIScript : MonoBehaviour
    {
        public abstract IBuilderManagerUI BuilderManagerUI { get; }
    }
}