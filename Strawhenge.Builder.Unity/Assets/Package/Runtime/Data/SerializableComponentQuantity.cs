using Strawhenge.Builder.Unity.ScriptableObjects;
using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Data
{
    [Serializable]
    public class SerializableComponentQuantity
    {
        [SerializeField] ComponentScriptableObject _component;
        [SerializeField, Min(1)] int _quantity;

        public ComponentScriptableObject Component => _component;

        public int Quantity => _quantity;
    }
}