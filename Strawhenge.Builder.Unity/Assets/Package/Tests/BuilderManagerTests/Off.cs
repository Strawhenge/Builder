using NUnit.Framework;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests
{
    public class Off : BaseBuilderManagerTest
    {
        protected override void Act()
        {
            BuilderOn();
            BuilderOff();
        }

        [Test]
        public void Builder_markers_should_not_be_visible()
        {
            VerifyAllMarkersNotVisible();
        }

        [Test]
        public void Build_item_selector_should_disable()
        {
            VerifyExistingBuildItemSelectorDisabled();
        }

        [Test]
        public void Should_disable_builder_manager_UI()
        {
            VerifyBuilderManagerUIDisabled();
        }
    }
}