using NUnit.Framework;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests
{
    public class ExitViaManagerUI : BaseBuilderManagerTest
    {
        protected override void Act()
        {
            BuilderOn();
            InvokeBuilderManagerUIExit();
        }

        [Test]
        public void Builder_markers_should_not_be_visible()
        {
            VerifyAllMarkersNotVisible();
        }

        [Test]
        public void Build_item_selector_should_disable()
        {
            VerifyExistingBuildItemSelectorDisabled();
        }

        [Test]
        public void Builder_manager_UI_should_be_disabled()
        {
            VerifyBuilderManagerUIDisabled();
        }
    }
}