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

        void AssertMenuIsShowingFurnitureCategory()
        {
            Assert.True(_menuView.IsShowing);
            AssertCategories(Utility);
            AssertItems(Chair, Table);
            Assert.True(_menuView.IsBackEnabled);
        }

        void AssertMenuIsShowingUtilityCategory()
        {
            Assert.True(_menuView.IsShowing);
            AssertNoCategories();
            AssertItems(Workbench);
            Assert.True(_menuView.IsBackEnabled);
        }

        void AssertMenuIsShowingStructureCategory()
        {
            Assert.True(_menuView.IsShowing);
            AssertNoCategories();
            AssertItems(Wall, Floor);
            Assert.True(_menuView.IsBackEnabled);
        }

        void AssertCategories(params string[] categories)
        {
            Assert.Equal(categories.Length, _menuView.CurrentCategories.Count);

            for (int i = 0; i < categories.Length; i++)
                Assert.Equal(categories[i], _menuView.CurrentCategories[i]);
        }

        void AssertItems(params string[] items)
        {
            Assert.Equal(items.Length, _menuView.CurrentItems.Count);

            for (int i = 0; i < items.Length; i++)
                Assert.Equal(items[i], _menuView.CurrentItems[i]);
        }

        void AssertNoCategories() => Assert.Empty(_menuView.CurrentCategories);

        void AssertNoItems() => Assert.Empty(_menuView.CurrentItems);

        void AssertItemSelected(string item) => 
            Assert.Equal(item, Assert.Single(_selectedItems));
    }
}
