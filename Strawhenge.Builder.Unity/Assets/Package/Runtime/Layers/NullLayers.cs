using System;

namespace Strawhenge.Builder.Unity
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