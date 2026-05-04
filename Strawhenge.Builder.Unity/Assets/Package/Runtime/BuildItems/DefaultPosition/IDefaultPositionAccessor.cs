using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.DefaultPosition
{
    public interface IDefaultPositionAccessor
    {
        Vector3 GetPosition();

        Quaternion GetRotation();
    }
}