using NUnit.Framework;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests.TestCases
{
    public class On : BaseBuilderManagerTest
    {
        protected override void Act()
        {
            BuilderOn();
        }

        [Test]
        public void Builder_markers_should_be_visible()
        {
            VerifyAllMarkersVisible();
        }

        [Test]
        public void Build_item_selector_should_enable()
        {
            VerifyExistingBuildItemSelectorEnabled();
        }

        [Test]
        public void Should_enable_builder_manager_UI()
        {
            VerifyBuilderManagerUIEnabled();
        }
    }
}