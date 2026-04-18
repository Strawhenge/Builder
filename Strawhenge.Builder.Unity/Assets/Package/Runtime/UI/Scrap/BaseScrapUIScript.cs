using UnityEngine;

namespace Strawhenge.Builder.Unity.UI
{
    public abstract class BaseScrapUIScript : MonoBehaviour
    {
        public abstract IScrapUI ScrapUI { get; }
    }
}