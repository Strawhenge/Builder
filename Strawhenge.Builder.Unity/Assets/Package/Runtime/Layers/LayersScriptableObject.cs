using Strawhenge.Common;
using Strawhenge.Common.Unity.Serialization;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Layers
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/Layers")]
    public class LayersScriptableObject : ScriptableObject, ILayers
    {
        [SerializeField] Layer[] _markerLayers;

        public int[] MarkerLayers => _markerLayers.ToArray(x => x.Value);
    }
}