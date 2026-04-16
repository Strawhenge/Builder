using NUnit.Framework;
using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Builder.Unity.Tests.Fakes;
using Strawhenge.Builder.Unity.UI;
using Strawhenge.Common.Logging;
using System;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests
{
    public abstract class BaseBuilderManagerTest
    {
        const int EnvironmentLayer = 1;
        static readonly int[] MarkerLayers = { 2, 3, 4 };

        static readonly ILayers Layers = new LayersFake()
        {
            MarkerLayers = MarkerLayers
        };

        readonly BuildItemSelectorFake _existingBuildItemSelector;
        readonly BuilderManagerUIFake _builderManagerUI;

        readonly Camera _camera;
        readonly MenuViewFake _menuView;

        // TODO Allow individual tests to setup repo.
        readonly BlueprintFake _chair = new("Chair", SetUpBuildItemScript()); 
        readonly BlueprintRepositoryFake _blueprintRepository;

        protected BaseBuilderManagerTest()
        {
            _existingBuildItemSelector = new BuildItemSelectorFake();
            _builderManagerUI = new BuilderManagerUIFake();

            var logger = NullLogger.Instance; // TODO Forward logs to test output.
            var inventory = new ComponentInventory(logger);

            _camera = new GameObject().AddComponent<Camera>();
            _camera.cullingMask = EnvironmentLayer;

            _menuView = new MenuViewFake();
            _blueprintRepository = new BlueprintRepositoryFake();

            _blueprintRepository.Blueprints.Add(_chair);

            Sut = new BuilderManager(
                inventory,
                _existingBuildItemSelector,
                _camera,
                new CameraControllerFake(),
                new DefaultPositionAccessorFake(),
                _builderManagerUI,
                _menuView,
                new NullRecipeUI(),
                new NullScrapUI(),
                _blueprintRepository,
                DefaultControlsSettings.Instance,
                Layers,
                logger);
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

        protected bool IsBuildItemControllerEnabled() => throw new NotImplementedException();
        //_buildItemController.IsOn;

        protected void InvokeBuilderManagerUIExit() => _builderManagerUI.InvokeExitBuilder();

        protected void InvokePlaceSelectedItem() => throw new NotImplementedException();
        //_buildItemController.InvokePlaceItem();

        protected void InvokeCancelSelectedItem() => throw new NotImplementedException();
        //_buildItemController.InvokeCancel();

        protected void InvokeOpenMenu() => _builderManagerUI.InvokeOpenMenu();

        protected void InvokeCloseMenu() => _menuView.InvokeSelectExit();

        protected void InvokeSelectFromMenu() => _menuView.InvokeSelectItem(_chair.Name);

        protected bool IsMenuOpen() => _menuView.IsShowing;

        static BuildItemScript SetUpBuildItemScript() => new GameObject().AddComponent<BuildItemScript>();
    }
}