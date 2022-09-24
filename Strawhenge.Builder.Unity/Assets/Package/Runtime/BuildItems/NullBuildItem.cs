using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class NullBuildItem : IBuildItem
    {
        public void Cancel()
        {
        }

        public void Finalize(Vector3 position, Quaternion rotation)
        {
        }

        public IBuildItemPreview Preview(Vector3 position, Quaternion rotation) => new NullBuildItemPreview();
    }
}