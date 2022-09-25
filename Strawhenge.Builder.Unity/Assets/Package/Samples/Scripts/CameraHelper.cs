using Strawhenge.Builder.Unity.BuildItems;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class CameraHelper : MonoBehaviour
    {
        [SerializeField] float _distance;

        Camera _camera;
        IBuildItemController _buildItemController;

        void Awake()
        {
            _camera = FindObjectOfType<Camera>();
        }

        void Start()
        {
            _buildItemController = FindObjectOfType<Context>().BuildItemController;
        }

        void Update()
        {
            _buildItemController.CurrentPreview
                .Do(UpdateCameraPosition);
        }

        void UpdateCameraPosition(IBuildItemPreview buildItem)
        {
            var direction = _camera.transform.forward.normalized * -1;

            _camera.transform.position = buildItem.Position + direction * _distance;
        }
    }
}
