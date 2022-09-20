using Strawhenge.Builder.Unity.Factories;
using Strawhenge.Builder.Unity.Monobehaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class BuildItemClick : MonoBehaviour
    {
        [SerializeField] Camera _camera;

        BlueprintManager _blueprintManager;
        BlueprintFactory _blueprintFactory;

        void Start()
        {
            var context = FindObjectOfType<Context>();
            _blueprintManager = context.BlueprintManager;
            _blueprintFactory = context.BlueprintFactory;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) &&
                Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var hit))
            {
                var buildItem = hit.transform.root.GetComponentInChildren<BuildItemScript>();

                if (buildItem != null)
                {

                }
            }
        }
    }
}
