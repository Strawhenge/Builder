using Strawhenge.Builder.Unity;
using Strawhenge.Builder.Unity.Monobehaviours;
using System;
using UnityEngine;

namespace Sample
{
    public class MouseClickBuildItemSelectorScript : BaseBuildItemScriptSelectorScript, IBuildItemScriptSelector
    {
        [SerializeField] Camera _camera;

        public override IBuildItemScriptSelector BuildItemScriptSelector => this;

        public event Action<BuildItemScript> Select;

        public void Enable()
        {
            enabled = true;
        }

        public void Disable()
        {
            enabled = false;
        }

        void Awake()
        {
            enabled = false;
        }

        void Update()
        {
            HandleExistingItemClick();
        }

        void HandleExistingItemClick()
        {
            if (!UnityEngine.Input.GetMouseButtonDown(0) ||
                !Physics.Raycast(_camera.ScreenPointToRay(UnityEngine.Input.mousePosition), out var hit))
                return;

            var buildItemScript = hit.transform.root.GetComponentInChildren<BuildItemScript>();

            if (buildItemScript != null)
                Select?.Invoke(buildItemScript);
        }
    }
}