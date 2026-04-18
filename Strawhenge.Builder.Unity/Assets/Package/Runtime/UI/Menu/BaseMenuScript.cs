using Strawhenge.Builder.Menu;
using UnityEngine;

namespace Strawhenge.Builder.Unity.UI.Menu
{
    public abstract class BaseMenuScript : MonoBehaviour
    {
        public abstract IMenuView MenuView { get; }
    }
}