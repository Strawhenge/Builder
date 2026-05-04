using NUnit.Framework;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests.TestCases
{
    public class SelectExistingItem : BaseBuilderManagerTest
    {
        protected override void Act()
        {
            BuilderOn();
            InvokeExistingItemSelected();
        }

        [Test]
        public void Build_item_selector_should_disable()
        {
            VerifyExistingBuildItemSelectorDisabled();
        }

        [Test]
        public void Build_item_should_be_controlled()
        {
            VerifyBuildItemControlsEnabled();
        }

        [Test]
        public void Manager_UI_should_be_disabled()
        {
            VerifyBuilderManagerUIDisabled();
        }
    }
}