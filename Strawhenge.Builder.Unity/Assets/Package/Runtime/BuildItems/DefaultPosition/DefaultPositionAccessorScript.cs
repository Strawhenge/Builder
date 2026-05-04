using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.DefaultPosition
{
    public abstract class DefaultPositionAccessorScript : MonoBehaviour
    {
        public abstract IDefaultPositionAccessor DefaultPositionAccessor { get; }
    }
}