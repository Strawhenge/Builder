using UnityEngine;

namespace Strawhenge.Builder.Unity.Progress
{
    public class BuildItemData
    {
        public BuildItemData(string name, Vector3 position, Quaternion rotation)
        {
            Name = name;
            Position = position;
            Rotation = rotation;
        }

        public string Name { get; }

        public Vector3 Position { get; }

        public Quaternion Rotation { get; }
    }
}