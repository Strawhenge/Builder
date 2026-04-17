using NUnit.Framework;
using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Builder.Unity.Tests.Fakes;
using Strawhenge.Builder.Unity.UI;
using System.Collections.Generic;
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
        readonly BlueprintRepositoryFake _blueprintRepository;
        readonly BuilderManager _builder;

        protected BaseBuilderManagerTest()
        {
            _existingBuildItemSelector = new BuildItemSelectorFake();
            _builderManagerUI = new BuilderManagerUIFake();

            var logger = new TestContextLogger();
            var inventory = new ComponentInventory(logger);

            _camera = new GameObject().AddComponent<Camera>();
            _camera.cullingMask = EnvironmentLayer;

            _menuView = new MenuViewFake();
            _blueprintRepository = new BlueprintRepositoryFake();

            _builder = new BuilderManager(
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

        [OneTimeSetUp]
        protected void SetUp()
        {
            _blueprintRepository.Blueprints.AddRange(GetBlueprints());
            Act();
        }

        protected abstract void Act();

        protected virtual IEnumerable<IBlueprint> GetBlueprints() => Enumerable.Empty<BlueprintFake>();

        protected void BuilderOn() => _builder.On();

        protected void BuilderOff() => _builder.Off();

        protected bool AllMarkersVisible() => MarkerLayers
            .All(layer => ((_camera.cullingMask & (1 << layer)) != 0));

        protected bool AllMarkersNotVisible() => MarkerLayers
            .All(layer => ((_camera.cullingMask & (1 << layer)) == 0));

        protected bool IsExistingBuildItemSelectorEnabled() => _existingBuildItemSelector.IsEnabled;

        protected bool IsBuilderManagerUIEnabled() => _builderManagerUI.IsEnabled;

        protected void InvokeExistingItemSelected() => _existingBuildItemSelector.InvokeSelect(SetUpBuildItemScript());

        protected bool IsBuildItemControllerEnabled() => _builder.Controls.BuildItem.IsEnabled;

        protected void InvokeBuilderManagerUIExit() => _builderManagerUI.InvokeExitBuilder();

        protected void InvokePlaceSelectedItem() => _builder.Controls.BuildItem.Place();

        protected void InvokeCancelSelectedItem() => _builder.Controls.BuildItem.Cancel();

        protected void InvokeOpenMenu() => _builderManagerUI.InvokeOpenMenu();

        protected void InvokeCloseMenu() => _menuView.InvokeSelectExit();

        protected void InvokeSelectFromMenu(string name) => _menuView.InvokeSelectItem(name);

        protected bool IsMenuOpen() => _menuView.IsShowing;

        static BuildItemScript SetUpBuildItemScript() => new GameObject().AddComponent<BuildItemScript>();
    }
}