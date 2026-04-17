using NUnit.Framework;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests.TestCases
{
    public class CloseMenu : BaseBuilderManagerTest
    {
        protected override void Act()
        {
            BuilderOn();
            InvokeOpenMenu();
            InvokeCloseMenu();
        }

        [Test]
        public void Menu_should_be_closed()
        {
            VerifyMenuIsNotOpen();
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