using NUnit.Framework;
using Strawhenge.Builder.Unity.Blueprints;
using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.BuildItems.Controls;
using Strawhenge.Builder.Unity.Layers;
using Strawhenge.Builder.Unity.Manager;
using Strawhenge.Builder.Unity.UI;
using Strawhenge.Builder.Unity.UI.Recipe;
using Strawhenge.Builder.Unity.UI.Scrap;
using Strawhenge.Builder.Unity.Tests.Fakes;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests
{
    public abstract partial class BaseBuilderManagerTest
    {
        const int EnvironmentLayer = 1;
        static readonly int[] MarkerLayers = { 2, 3, 4 };

        static readonly ILayers Layers = new LayersFake()
        {
            MarkerLayers = MarkerLayers
        };

        readonly BuildItemSelectorFake _existingBuildItemSelector;
        readonly BuilderManagerUIFake _builderManagerUI;

        readonly UnityEngine.Camera _camera;
        readonly MenuViewFake _menuView;
        readonly BlueprintRepositoryFake _blueprintRepository;
        readonly BuilderManager _builder;

        protected BaseBuilderManagerTest()
        {
            _existingBuildItemSelector = new BuildItemSelectorFake();
            _builderManagerUI = new BuilderManagerUIFake();

            var logger = new TestContextLogger();
            var inventory = new ComponentInventory(logger);

            _camera = new GameObject().AddComponent<UnityEngine.Camera>();
            _camera.cullingMask = EnvironmentLayer;

            _menuView = new MenuViewFake();
            _blueprintRepository = new BlueprintRepositoryFake();

            _builder = new BuilderManager(
                inventory,
                _existingBuildItemSelector,
                _camera,
                new CameraControllerFake(),
                new DefaultPositionAccessorFake(),
                new GameObject(BuildItemsParent.Name).transform,
                new BuilderUIContainer(_builderManagerUI,
                    _menuView,
                    NullRecipeUI.Instance,
                    NullScrapUI.Instance),
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

        protected void InvokeExistingItemSelected() => _existingBuildItemSelector.InvokeSelect(SetUpBuildItemScript());

        protected void InvokeBuilderManagerUIExit() => _builderManagerUI.InvokeExitBuilder();

        protected void InvokePlaceSelectedItem() => _builder.Controls.BuildItem.Place();

        protected void InvokeCancelSelectedItem() => _builder.Controls.BuildItem.Cancel();

        protected void InvokeOpenMenu() => _builderManagerUI.InvokeOpenMenu();

        protected void InvokeCloseMenu() => _menuView.InvokeSelectExit();

        protected void InvokeSelectFromMenu(string name) => _menuView.InvokeSelectItem(name);

        protected void InvokeSelectCategoryFromMenu(string name) => _menuView.InvokeSelectCategory(name);

        protected void InvokeBackOnMenu() => _menuView.InvokeSelectBack();

        static BuildItemScript SetUpBuildItemScript() => new GameObject().AddComponent<BuildItemScript>();
    }
}