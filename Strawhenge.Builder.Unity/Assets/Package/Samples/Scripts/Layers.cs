using Strawhenge.Builder.Unity;
using UnityEngine;

class Layers : ILayers
{
    public static Layers Instance { get; } = new Layers();

    Layers()
    {
        MarkerLayers = new[]
        {
            LayerMask.NameToLayer("WallSideSnap"),
            LayerMask.NameToLayer("FloorEdgeSnap"),
            LayerMask.NameToLayer("WallBottomSnap")
        };
    }

    public int[] MarkerLayers { get; }
}