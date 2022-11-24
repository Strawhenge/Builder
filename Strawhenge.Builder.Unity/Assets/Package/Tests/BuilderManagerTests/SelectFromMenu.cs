using NUnit.Framework;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests
{
    public class SelectFromMenu : BaseBuilderManagerTest
    {
        protected override void Act()
        {
            Sut.On();
            InvokeOpenMenu();
            InvokeSelectFromMenu();
        }

        [Test]
        public void Menu_should_be_closed()
        {
            Assert.False(IsMenuOpen());
        }

        [Test]
        public void Build_item_should_be_controlled()
        {
            Assert.True(IsBuildItemControllerEnabled());
        }
    }
}