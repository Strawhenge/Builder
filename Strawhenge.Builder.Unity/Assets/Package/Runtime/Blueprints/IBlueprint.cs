using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.Components;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.Blueprints
{
    public interface IBlueprint : ICategorizable
    {
        BuildItemScript BuildItem { get; }
        
        IReadOnlyList<SerializableComponentQuantity>  Recipe { get; }
    }
}