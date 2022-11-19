using NUnit.Framework;
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
            var sut = new BuilderManager(camera, LayersAccessor);

            sut.On();

            Assert.True(
                AllMarkersVisible(camera));
        }

        [Test]
        public void Builder_markers_layers_should_not_be_visible_when_builder_is_disabled()
        {
            var camera = SetUpCamera();
            var sut = new BuilderManager(camera, LayersAccessor);

            sut.On();
            sut.Off();

            Assert.True(
                AllMarkersNotVisible(camera));
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
}
