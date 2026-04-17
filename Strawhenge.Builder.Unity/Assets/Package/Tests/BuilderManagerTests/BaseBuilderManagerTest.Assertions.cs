using NUnit.Framework;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests
{
    public abstract partial class BaseBuilderManagerTest
    {
        protected void VerifyAllMarkersVisible() =>
            Assert.That(MarkerLayers,
                Is.All.Matches<int>(layer => (_camera.cullingMask & (1 << layer)) != 0));

        protected void VerifyAllMarkersNotVisible() =>
            Assert.That(MarkerLayers,
                Is.All.Matches<int>(layer => (_camera.cullingMask & (1 << layer)) == 0));

        protected void VerifyExistingBuildItemSelectorEnabled() =>
            Assert.That(_existingBuildItemSelector.IsEnabled, Is.True);

        protected void VerifyExistingBuildItemSelectorDisabled() =>
            Assert.That(_existingBuildItemSelector.IsEnabled, Is.False);

        protected void VerifyBuilderManagerUIEnabled() =>
            Assert.That(_builderManagerUI.IsEnabled, Is.True);

        protected void VerifyBuilderManagerUIDisabled() =>
            Assert.That(_builderManagerUI.IsEnabled, Is.False);

        protected void VerifyMenuIsOpen() =>
            Assert.That(_menuView.IsShowing, Is.True);

        protected void VerifyMenuIsNotOpen() =>
            Assert.That(_menuView.IsShowing, Is.False);

        protected void VerifyMenuIsShowingCategories(params string[] categories) =>
            CollectionAssert.AreEquivalent(categories, _menuView.Categories);

        protected void VerifyMenuIsShowingItems(params string[] items) =>
            CollectionAssert.AreEquivalent(items, _menuView.Items);

        protected void VerifyBuildItemControlsEnabled() =>
            Assert.That(_builder.Controls.BuildItem.IsEnabled, Is.True);
    }
}