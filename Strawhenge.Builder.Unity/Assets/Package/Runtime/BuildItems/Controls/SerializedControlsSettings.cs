using Strawhenge.Builder.Unity.BuildItems.Controls.BuildItem;
using Strawhenge.Builder.Unity.BuildItems.Controls.HorizontalSnap;
using Strawhenge.Builder.Unity.BuildItems.Controls.VerticalSnap;
using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Controls
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