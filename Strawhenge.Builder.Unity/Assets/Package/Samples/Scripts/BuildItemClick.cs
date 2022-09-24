using Strawhenge.Builder.Unity.BuildItems;
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

        IBuildItemController _buildItemController;

        void Start()
        {
            var context = FindObjectOfType<Context>();

            _buildItemController = context.BuildItemController;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) &&
                Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var hit))
            {
                var buildItemScript = hit.transform.root.GetComponentInChildren<BuildItemScript>();

                if (buildItemScript != null)
                {
                    var buildItem = new ExistingBuildItem(buildItemScript);

                    _buildItemController
                        .PreviewOn(buildItem);
                }
            }
        }
    }
}
