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
        public void Build_item_selector_should_disable_when_item_is_selected()
        {
            Assert.False(IsExistingBuildItemSelectorEnabled());
        }

        [Test]
        public void Build_item_should_be_controlled_when_item_is_selected()
        {
            Assert.True(IsBuildItemControllerEnabled());
        }
    }
}