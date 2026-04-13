using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public abstract class DefaultPositionAccessorScript : MonoBehaviour
    {
        public abstract IDefaultPositionAccessor DefaultPositionAccessor { get; }
    }
}