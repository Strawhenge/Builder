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
            VerifyExistingBuildItemSelectorEnabled();
        }

        [Test]
        public void Builder_manager_UI_should_be_enabled()
        {
            VerifyBuilderManagerUIEnabled();
        }
    }
}