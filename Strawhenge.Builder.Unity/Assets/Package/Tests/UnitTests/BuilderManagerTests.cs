using NUnit.Framework;
using Strawhenge.Builder.Unity.Monobehaviours;
using System;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests.UnitTests
{
    public class BuilderManagerTests
    {
        const int EnvironmentLayer = 1;
        static readonly int[] MarkerLayers = { 2, 3, 4 };

        static readonly ILayersAccessor LayersAccessor = new LayersFake()
        {
            MarkerLayers = MarkerLayers
        };

        [Test]
        public void Builder_markers_layers_should_be_visible_when_builder_is_enabled()
        {
            var camera = SetUpCamera();
            var sut = new BuilderManager(new BuildItemSelectorFake(), camera, LayersAccessor);

            sut.On();

            Assert.True(
                AllMarkersVisible(camera));
        }

        [Test]
        public void Builder_markers_layers_should_not_be_visible_when_builder_is_disabled()
        {
            var camera = SetUpCamera();
            var sut = new BuilderManager(new BuildItemSelectorFake(), camera, LayersAccessor);

            sut.On();
            sut.Off();

            Assert.True(
                AllMarkersNotVisible(camera));
        }

        [Test]
        public void Build_item_selector_should_enable_when_build_is_enabled()
        {
            var selector = new BuildItemSelectorFake();
            var sut = new BuilderManager(selector, SetUpCamera(), LayersAccessor);

            sut.On();

            Assert.True(selector.IsEnabled);
        }

        [Test]
        public void Build_item_selector_should_disable_when_build_is_disabled()
        {
            var selector = new BuildItemSelectorFake();
            var sut = new BuilderManager(selector, SetUpCamera(), LayersAccessor);

            sut.On();
            sut.Off();

            Assert.False(selector.IsEnabled);
        }

        static bool AllMarkersVisible(Camera camera) => MarkerLayers
            .All(layer => ((camera.cullingMask & (1 << layer)) != 0));

        static bool AllMarkersNotVisible(Camera camera) => MarkerLayers
            .All(layer => ((camera.cullingMask & (1 << layer)) == 0));

        static Camera SetUpCamera()
        {
            var camera = new GameObject().AddComponent<Camera>();

            camera.cullingMask = EnvironmentLayer;
            return camera;
        }
    }

    class BuildItemSelectorFake : IBuildItemSelector
    {
        public event Action<BuildItemScript> Select;

        public void Enable() => IsEnabled = true;

        public void Disable() => IsEnabled = false;

        internal bool IsEnabled { get; private set; }

        internal void InvokeSelect(BuildItemScript buildItem) => Select?.Invoke(buildItem);
    }
}
