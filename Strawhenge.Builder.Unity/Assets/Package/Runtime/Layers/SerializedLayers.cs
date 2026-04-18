using Strawhenge.Common;
using Strawhenge.Common.Unity.Serialization;
using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Layers
{
    [Serializable]
    public class SerializedLayers : ScriptableObject, ILayers
    {
        [SerializeField] Layer[] _markerLayers;

        public int[] MarkerLayers => _markerLayers.ToArray(x => x.Value);
    }
}