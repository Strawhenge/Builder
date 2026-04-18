using System;

namespace Strawhenge.Builder.Unity.Layers
{
    class NullLayers : ILayers
    {
        public static ILayers Instance { get; } = new NullLayers();

        NullLayers()
        {
        }

        public int[] MarkerLayers => Array.Empty<int>();
    }
}