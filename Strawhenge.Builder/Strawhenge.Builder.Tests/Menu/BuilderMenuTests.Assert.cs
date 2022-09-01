using Xunit;

namespace Strawhenge.Builder.Tests.Menu
{
    public partial class BuilderMenuTests
    {
        void AssertMenuIsHidden() => Assert.False(_menuView.IsShowing);

        void AssertMenuIsShowingMainCategory()
        {
            Assert.True(_menuView.IsShowing);
            AssertCategories(Structure, Furniture);
            AssertNoItems();
            Assert.False(_menuView.IsBackEnabled);
        }

        void AssertCategories(params string[] categories)
        {
            Assert.Equal(categories.Length, _menuView.CurrentCategories.Count);

            for (int i = 0; i < categories.Length; i++)
                Assert.Equal(categories[i], _menuView.CurrentCategories[i]);
        }

        void AssertNoItems()
        {
            Assert.Empty(_menuView.CurrentItems);
        }
    }
}
