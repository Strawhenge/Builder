using Strawhenge.Builder.Unity.Tests.Fakes;
using Strawhenge.Builder.Unity.UI;
using Strawhenge.Common.Logging;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests
{
    class Context
    {
        const int EnvironmentLayer = 1;
        static readonly int[] MarkerLayers = { 2, 3, 4 };

        static readonly ILayersAccessor LayersAccessor = new LayersFake()
        {
            MarkerLayers = MarkerLayers
        };

        internal static Context Create()
        {
            var camera = new GameObject().AddComponent<Camera>();
            camera.cullingMask = EnvironmentLayer;

            return new Context(camera);
        }

        readonly Camera _camera;

        Context(Camera camera)
        {
            _camera = camera;
        }

        internal BuildItemSelectorFake ExistingBuildItemSelector { get; } = new BuildItemSelectorFake();

        internal BuildItemControllerFake BuildItemController { get; } = new BuildItemControllerFake();

        internal BuilderManagerUIFake BuilderManagerUI { get; } = new BuilderManagerUIFake();

        internal BuilderManager CreateSut()
        {
            var logger = new NullLogger();
            var inventory = new ComponentInventory(logger);
            var existingBlueprintManager =
                new ExistingBlueprintManager(inventory, BuildItemController, new NullScrapUI());
            var existingBlueprintFactory = new ExistingBlueprintFactory();

            return new BuilderManager(
                ExistingBuildItemSelector,
                _camera,
                LayersAccessor,
                existingBlueprintManager,
                existingBlueprintFactory,
                BuilderManagerUI);
        }

        internal bool AllMarkersVisible() => MarkerLayers
            .All(layer => ((_camera.cullingMask & (1 << layer)) != 0));

        internal bool AllMarkersNotVisible() => MarkerLayers
            .All(layer => ((_camera.cullingMask & (1 << layer)) == 0));
    }
}
