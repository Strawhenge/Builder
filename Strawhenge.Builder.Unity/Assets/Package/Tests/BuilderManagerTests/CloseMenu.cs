using NUnit.Framework;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests
{
    public class CloseMenu : BaseBuilderManagerTest
    {
        protected override void Act()
        {
            Sut.On();
            InvokeOpenMenu();
            InvokeCloseMenu();
        }

        [Test]
        public void Menu_should_be_closed()
        {
            Assert.False(IsMenuOpen());
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