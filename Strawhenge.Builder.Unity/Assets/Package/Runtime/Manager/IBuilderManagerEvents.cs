using System;

namespace Strawhenge.Builder.Unity
{
    public interface IBuilderManagerEvents
    {
        event Action TurningOn;

        event Action TurnedOff;
    }
}