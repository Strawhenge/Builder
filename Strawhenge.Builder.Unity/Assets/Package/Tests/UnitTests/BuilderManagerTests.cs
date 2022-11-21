using NUnit.Framework;
using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Builder.Unity.Tests.Fakes;
using Strawhenge.Builder.Unity.UI;
using Strawhenge.Common.Logging;
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
            var sut = CreateSut(out Camera camera);

            sut.On();

            Assert.True(
                AllMarkersVisible(camera));
        }

        [Test]
        public void Builder_markers_layers_should_not_be_visible_when_builder_is_disabled()
        {
            var sut = CreateSut(out Camera camera);

            sut.On();
            sut.Off();

            Assert.True(
                AllMarkersNotVisible(camera));
        }

        [Test]
        public void Build_item_selector_should_enable_when_build_is_enabled()
        {
            var sut = CreateSut(out BuildItemSelectorFake selector);

            sut.On();

            Assert.True(selector.IsEnabled);
        }

        [Test]
        public void Build_item_selector_should_disable_when_build_is_disabled()
        {
            var sut = CreateSut(out BuildItemSelectorFake selector);

            sut.On();
            sut.Off();

            Assert.False(selector.IsEnabled);
        }

        [Test]
        public void Build_item_selector_should_disable_when_item_is_selected()
        {
            var sut = CreateSut(out BuildItemSelectorFake selector);

            sut.On();
            selector.InvokeSelect(SetUpBuildItemScript());

            Assert.False(selector.IsEnabled);
        }

        [Test]
        public void Build_item_should_be_controlled_when_item_is_selected()
        {
            var sut = CreateSut(out BuildItemSelectorFake selector, out BuildItemControllerFake buildItemController);

            sut.On();
            selector.InvokeSelect(SetUpBuildItemScript());

            Assert.True(buildItemController.IsOn);
        }

        static BuilderManager CreateSut(out Camera camera) => CreateSut(out _, out camera, out _);

        static BuilderManager CreateSut(out BuildItemSelectorFake selector) => CreateSut(out selector, out _, out _);

        static BuilderManager CreateSut(out BuildItemSelectorFake selector, out BuildItemControllerFake buildItemController) =>
            CreateSut(out selector, out _, out buildItemController);

        static BuilderManager CreateSut(out BuildItemSelectorFake selector, out Camera camera, out BuildItemControllerFake buildItemController)
        {
            selector = new BuildItemSelectorFake();
            camera = SetUpCamera();
            buildItemController = new BuildItemControllerFake();

            var logger = new NullLogger();
            var inventory = new ComponentInventory(logger);
            var existingBlueprintManager =
                new ExistingBlueprintManager(inventory, buildItemController, new NullScrapUI());
            var existingBlueprintFactory = new ExistingBlueprintFactory();

            return new BuilderManager(selector, camera, LayersAccessor, existingBlueprintManager, existingBlueprintFactory);
        }

        static BuildItemScript SetUpBuildItemScript() => new GameObject().AddComponent<BuildItemScript>();

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
