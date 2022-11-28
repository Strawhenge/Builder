using Strawhenge.Builder.Unity.Monobehaviours;
using System;

namespace Strawhenge.Builder.Unity
{
    public interface IBuildItemScriptSelector
    {
        event Action<BuildItemScript> Select;

        void Enable();

        void Disable();
    }
}