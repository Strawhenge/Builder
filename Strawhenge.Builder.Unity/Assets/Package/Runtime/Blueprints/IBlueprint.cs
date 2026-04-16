using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity.Data;
using Strawhenge.Builder.Unity.Monobehaviours;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.ScriptableObjects
{
    public interface IBlueprint : ICategorizable
    {
        BuildItemScript BuildItem { get; }
        
        IReadOnlyList<SerializableComponentQuantity>  Recipe { get; }
    }
}