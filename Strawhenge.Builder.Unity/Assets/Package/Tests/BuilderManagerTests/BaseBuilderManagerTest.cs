using NUnit.Framework;
using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Builder.Unity.Tests.Fakes;
using Strawhenge.Builder.Unity.UI;
using Strawhenge.Common.Logging;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests
{
    public abstract class BaseBuilderManagerTest
    {
        const int EnvironmentLayer = 1;
        static readonly int[] MarkerLayers = { 2, 3, 4 };

        static readonly ILayersAccessor LayersAccessor = new LayersFake()
        {
            MarkerLayers = MarkerLayers
        };

        readonly BuildItemScriptSelectorFake _existingBuildItemSelector;
        readonly BuildItemControllerFake _buildItemController;
        readonly BuilderManagerUIFake _builderManagerUI;
        readonly BlueprintScriptableObjectMenuFake _menu;
        readonly Camera _camera;

        protected BaseBuilderManagerTest()
        {
            _existingBuildItemSelector = new BuildItemScriptSelectorFake();
            _buildItemController = new BuildItemControllerFake();
            _builderManagerUI = new BuilderManagerUIFake();
            _menu = new BlueprintScriptableObjectMenuFake();

            var logger = new NullLogger();
            var inventory = new ComponentInventory(logger);

            var existingBlueprintManager =
                new ExistingBlueprintManager(inventory, _buildItemController, new NullScrapUI());

            var blueprintManager = new BlueprintManager(inventory, _buildItemController, new NullRecipeUI());
            var blueprintFactory = new BlueprintFactoryFake();

            _camera = new GameObject().AddComponent<Camera>();
            _camera.cullingMask = EnvironmentLayer;

            var markers = new MarkersToggle(_camera, LayersAccessor);

            Sut = new BuilderManager(
                _existingBuildItemSelector,
                markers,
                existingBlueprintManager,
                blueprintManager,
                blueprintFactory,
                _builderManagerUI,
                _menu);
        }

        protected BuilderManager Sut { get; }

        [OneTimeSetUp]
        protected abstract void Act();

        protected bool AllMarkersVisible() => MarkerLayers
            .All(layer => ((_camera.cullingMask & (1 << layer)) != 0));

        protected bool AllMarkersNotVisible() => MarkerLayers
            .All(layer => ((_camera.cullingMask & (1 << layer)) == 0));

        protected bool IsExistingBuildItemSelectorEnabled() => _existingBuildItemSelector.IsEnabled;

        protected bool IsBuilderManagerUIEnabled() => _builderManagerUI.IsEnabled;

        protected void InvokeExistingItemSelected() => _existingBuildItemSelector.InvokeSelect(SetUpBuildItemScript());

        protected bool IsBuildItemControllerEnabled() => _buildItemController.IsOn;

        protected void InvokeBuilderManagerUIExit() => _builderManagerUI.InvokeExitBuilder();

        protected void InvokePlaceSelectedItem() => _buildItemController.InvokePlaceItem();
        
        protected void InvokeCancelSelectedItem() => _buildItemController.InvokeCancel();

        protected void InvokeOpenMenu() => _builderManagerUI.InvokeOpenMenu();

        protected void InvokeCloseMenu() => _menu.InvokeExit();

        protected void InvokeSelectFromMenu() => _menu.InvokeSelect(ScriptableObject.CreateInstance<BlueprintScriptableObject>());

        protected bool IsMenuOpen() => _menu.IsOpen;

        static BuildItemScript SetUpBuildItemScript() => new GameObject().AddComponent<BuildItemScript>();
    }
}
