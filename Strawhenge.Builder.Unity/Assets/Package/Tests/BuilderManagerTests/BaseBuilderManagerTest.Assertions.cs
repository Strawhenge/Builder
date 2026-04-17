using NUnit.Framework;
using System.Linq;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests
{
    public abstract partial class BaseBuilderManagerTest
    {
        protected void VerifyAllMarkersVisible() =>
            Assert.True(
                MarkerLayers.All(layer => (_camera.cullingMask & (1 << layer)) != 0));

        protected void VerifyAllMarkersNotVisible() =>
            Assert.True(MarkerLayers
                .All(layer => (_camera.cullingMask & (1 << layer)) == 0));

        protected void VerifyExistingBuildItemSelectorEnabled() =>
            Assert.True(_existingBuildItemSelector.IsEnabled);

        protected void VerifyExistingBuildItemSelectorDisabled() =>
            Assert.False(_existingBuildItemSelector.IsEnabled);

        protected void VerifyBuilderManagerUIEnabled() =>
            Assert.True(_builderManagerUI.IsEnabled);

        protected void VerifyBuilderManagerUIDisabled() =>
            Assert.False(_builderManagerUI.IsEnabled);

        protected void VerifyMenuIsOpen() => Assert.True(_menuView.IsShowing);

        protected void VerifyMenuIsNotOpen() => Assert.False(_menuView.IsShowing);

        protected void VerifyMenuIsShowingCategories(params string[] categories) =>
            Assert.True(categories
                .OrderBy(x => x)
                .SequenceEqual(_menuView.Categories.OrderBy(x => x)));

        protected void VerifyMenuIsShowingItems(params string[] items) =>
            Assert.True(items
                .OrderBy(x => x)
                .SequenceEqual(_menuView.Items.OrderBy(x => x)));

        protected void VerifyBuildItemControlsEnabled() =>
            Assert.True(_builder.Controls.BuildItem.IsEnabled);
    }
}