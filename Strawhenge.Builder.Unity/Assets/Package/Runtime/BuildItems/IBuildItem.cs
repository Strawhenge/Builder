using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public interface IBuildItem
    {
        void Cancel();

        void Finalize(Vector3 position, Quaternion rotation);

        IBuildItemPreview Preview(Vector3 position, Quaternion rotation);
    }
}