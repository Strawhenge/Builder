using NUnit.Framework;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests
{
    public class SelectExistingItem : BaseBuilderManagerTest
    {
        protected override void Act()
        {
            Sut.On();
            InvokeExistingItemSelected();
        }

        [Test]
        public void Build_item_selector_should_disable()
        {
            Assert.False(IsExistingBuildItemSelectorEnabled());
        }

        [Test]
        public void Build_item_should_be_controlled()
        {
            Assert.True(IsBuildItemControllerEnabled());
        }

        [Test]
        public void Manager_UI_should_be_disabled()
        {
            Assert.False(IsBuilderManagerUIEnabled());
        }
    }
}