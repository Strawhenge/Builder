using UnityEngine;

namespace Strawhenge.Builder.Unity.UI.Scrap
{
    public abstract class BaseScrapUIScript : MonoBehaviour
    {
        public abstract IScrapUI ScrapUI { get; }
    }
}