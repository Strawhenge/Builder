using Strawhenge.Builder.Menu;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public abstract class BaseMenuScript : MonoBehaviour
    {
        public abstract IMenuView MenuView { get; }
    }
}