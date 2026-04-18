using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Progress
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/Progress Data")]
    public class BuilderProgressDataScriptableObject : ScriptableObject, IBuilderProgressData
    {
        [SerializeField] SerializedBuildItemData[] _buildItems;

        public IReadOnlyList<IBuildItemData> BuildItems => _buildItems;
    }
}