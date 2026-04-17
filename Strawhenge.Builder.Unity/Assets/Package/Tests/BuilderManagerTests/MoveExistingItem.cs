using NUnit.Framework;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests
{
    public class MoveExistingItem : BaseBuilderManagerTest
    {
        protected override void Act()
        {
            BuilderOn();
            InvokeExistingItemSelected();
            InvokePlaceSelectedItem();
        }

        [Test]
        public void Build_item_selector_should_enable()
        {
            Assert.True(IsExistingBuildItemSelectorEnabled());
        }

        [Test]
        public void Builder_manager_UI_should_be_enabled()
        {
            Assert.True(IsBuilderManagerUIEnabled());
        }
    }
}