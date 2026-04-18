using UnityEngine;

namespace Strawhenge.Builder.Unity.Progress.Data
{
    public interface IBuildItemData
    {
        string Name { get; }
     
        Vector3 Position { get; }
        
        Quaternion Rotation { get; }
    }
}