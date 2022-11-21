using NUnit.Framework;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests
{
    public class On : BaseBuilderManagerTest
    {
        protected override void Act()
        {
            Sut.On();
        }

        [Test]
        public void Builder_markers_should_be_visible()
        {
            Assert.True(AllMarkersVisible());
        }

        [Test]
        public void Build_item_selector_should_enable()
        {
            Assert.True(IsExistingBuildItemSelectorEnabled());
        }

        [Test]
        public void Should_enable_builder_manager_UI()
        {
            Assert.True(IsBuilderManagerUIEnabled());
        }
    }
}