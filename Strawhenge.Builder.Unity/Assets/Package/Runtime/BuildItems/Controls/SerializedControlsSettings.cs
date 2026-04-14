using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    [Serializable]
    public class SerializedControlsSettings : IControlsSettings
    {
        [SerializeField] SerializedBuildItemControlsSettings _buildItem;
        [SerializeField] SerializedHorizontalSnapControlsSettings _horizontalSnap;
        [SerializeField] SerializedVerticalSnapControlsSettings _verticalSnap;

        public IBuildItemControlsSettings BuildItem => _buildItem;

        public IHorizontalSnapControlsSettings HorizontalSnap => _horizontalSnap;

        public IVerticalSnapControlsSettings VerticalSnap => _verticalSnap;
    }
}