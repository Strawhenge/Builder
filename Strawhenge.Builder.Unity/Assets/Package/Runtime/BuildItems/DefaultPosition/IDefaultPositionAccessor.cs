using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public interface IDefaultPositionAccessor
    {
        Vector3 GetPosition();

        Quaternion GetRotation();
    }
}