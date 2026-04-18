using System;

namespace Strawhenge.Builder.Unity.BuildItems.Selector
{
    public interface IBuildItemSelector
    {
        event Action<BuildItemScript> Select;

        void Enable();

        void Disable();
    }
}