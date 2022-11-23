using NUnit.Framework;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests
{
    public class OpenMenu : BaseBuilderManagerTest
    {
        protected override void Act()
        {
            Sut.On();
            InvokeOpenMenu();
        }

        [Test]
        public void Menu_should_be_open()
        {
            Assert.True(IsMenuOpen());
        }

        [Test]
        public void Build_item_selector_should_be_disabled()
        {
            Assert.False(IsExistingBuildItemSelectorEnabled());
        }

        [Test]
        public void Manager_UI_should_be_disabled()
        {
            Assert.False(IsBuilderManagerUIEnabled());
        }
    }
}
