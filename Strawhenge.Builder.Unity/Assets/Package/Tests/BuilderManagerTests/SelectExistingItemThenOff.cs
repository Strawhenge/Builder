using NUnit.Framework;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests
{
    public class SelectExistingItemThenOff : BaseBuilderManagerTest
    {
        protected override void Act()
        {
            BuilderOn();
            InvokeExistingItemSelected();
            BuilderOff();
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

        [Test]
        public void Menu_should_be_closed()
        {
            VerifyMenuIsNotOpen();
        }
    }
}