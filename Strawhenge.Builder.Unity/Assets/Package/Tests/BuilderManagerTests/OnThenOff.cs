using NUnit.Framework;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests
{
    public class OnThenOff : BaseBuilderManagerTest
    {
        protected override void Act()
        {
            Sut.On();
            Sut.Off();
        }

        [Test]
        public void Builder_markers_should_not_be_visible()
        {
            Assert.True(AllMarkersNotVisible());
        }

        [Test]
        public void Build_item_selector_should_disable()
        {
            Assert.False(IsExistingBuildItemSelectorEnabled());
        }

        [Test]
        public void Should_disable_builder_manager_UI()
        {
            Assert.False(IsBuilderManagerUIEnabled());
        }
    }
}