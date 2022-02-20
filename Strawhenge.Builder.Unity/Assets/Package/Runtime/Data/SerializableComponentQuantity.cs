using Strawhenge.Builder.Unity.ScriptableObjects;
using System;

namespace Strawhenge.Builder.Unity.Data
{
    [Serializable]
    public class SerializableComponentQuantity
    {
        public ComponentScriptableObject Component;
        public int Quantity;
    }
}