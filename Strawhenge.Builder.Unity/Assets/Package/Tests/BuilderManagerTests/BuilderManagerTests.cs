using NUnit.Framework;
using Strawhenge.Builder.Unity.Monobehaviours;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests
{
    public class BuilderManagerTests
    {
        [Test]
        public void Builder_markers_layers_should_be_visible_when_builder_is_enabled()
        {
            var context = Context.Create();
            var sut = context.CreateSut();

            sut.On();

            Assert.True(context.AllMarkersVisible());
        }

        [Test]
        public void Builder_markers_layers_should_not_be_visible_when_builder_is_disabled()
        {
            var context = Context.Create();
            var sut = context.CreateSut();

            sut.On();
            sut.Off();

            Assert.True(context.AllMarkersNotVisible());
        }

        [Test]
        public void Build_item_selector_should_enable_when_build_is_enabled()
        {
            var context = Context.Create();
            var sut = context.CreateSut();

            sut.On();

            Assert.True(context.ExistingBuildItemSelector.IsEnabled);
        }

        [Test]
        public void Build_item_selector_should_disable_when_build_is_disabled()
        {
            var context = Context.Create();
            var sut = context.CreateSut();

            sut.On();
            sut.Off();

            Assert.False(context.ExistingBuildItemSelector.IsEnabled);
        }

        [Test]
        public void Build_item_selector_should_disable_when_item_is_selected()
        {
            var context = Context.Create();
            var sut = context.CreateSut();

            sut.On();
            context.ExistingBuildItemSelector.InvokeSelect(SetUpBuildItemScript());

            Assert.False(context.ExistingBuildItemSelector.IsEnabled);
        }

        [Test]
        public void Build_item_should_be_controlled_when_item_is_selected()
        {
            var context = Context.Create();
            var sut = context.CreateSut();

            sut.On();
            context.ExistingBuildItemSelector.InvokeSelect(SetUpBuildItemScript());

            Assert.True(context.BuildItemController.IsOn);
        }

        [Test]
        public void Should_enable_builder_manager_UI_when_builder_enabled()
        {
            var context = Context.Create();
            var sut = context.CreateSut();

            sut.On();

            Assert.True(context.BuilderManagerUI.IsEnabled);
        }

        [Test]
        public void Should_disable_builder_manager_UI_when_builder_disabled()
        {
            var context = Context.Create();
            var sut = context.CreateSut();

            sut.On();
            sut.Off();

            Assert.False(context.BuilderManagerUI.IsEnabled);
        }

        static BuildItemScript SetUpBuildItemScript() => new GameObject().AddComponent<BuildItemScript>();
    }
}
