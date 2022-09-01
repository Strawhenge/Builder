using Strawhenge.Builder.Menu;
using Xunit;

namespace Strawhenge.Builder.Tests.Menu
{
    public partial class BuilderMenuTests
    {
        readonly BuilderMenu _menu;
        readonly MenuViewFake _menuView;

        public BuilderMenuTests()
        {
            _menuView = new MenuViewFake();
            _menu = new BuilderMenu(CreateMenuItemsProvider(), _menuView);
        }

        /*
         EXPECTED MENU LAYOUT:
          
         * Main
            * Furniture
                * Utility
                    * Workbench [item]
                * Chair [item]
                * Table [item]
            * Structure
                * Walls [item]
                * Floor [item]
         */

        [Fact]
        public void Show()
        {
            _menu.Show();

            AssertMenuIsShowingMainCategory();
        }

        [Fact]
        public void Hide()
        {
            _menu.Show();
            _menu.Hide();

            AssertMenuIsHidden();
        }

        [Fact]
        public void SelectCategory()
        {
            _menu.Show();
            _menuView.InvokeSelectCategory(Furniture);

            AssertMenuIsShowingFurnitureCategory();
        }

        [Fact]
        public void SelectCategoryThenAnotherCategory()
        {
            _menu.Show();
            _menuView.InvokeSelectCategory(Furniture);
            _menuView.InvokeSelectCategory(Utility);

            AssertMenuIsShowingUtilityCategory();
        }

        [Fact]
        public void SelectCategoryThenGoBack()
        {
            _menu.Show();
            _menuView.InvokeSelectCategory(Furniture);
            _menuView.InvokeSelectBack();

            AssertMenuIsShowingMainCategory();
        }

        [Fact]
        public void SelectCategoryThenAnotherCategoryThenGoBack()
        {
            _menu.Show();
            _menuView.InvokeSelectCategory(Furniture);
            _menuView.InvokeSelectCategory(Utility);
            _menuView.InvokeSelectBack();

            AssertMenuIsShowingFurnitureCategory();
        }

        [Fact]
        public void SelectCategoryThenAnotherCategoryThenGoBackThenGoBackAgain()
        {
            _menu.Show();
            _menuView.InvokeSelectCategory(Furniture);
            _menuView.InvokeSelectCategory(Utility);
            _menuView.InvokeSelectBack();
            _menuView.InvokeSelectBack();

            AssertMenuIsShowingMainCategory();
        }

        [Fact]
        public void SelectCategoryThenAnotherCategoryThenGoBackThenGoBackAgainThenSelectAnotherCategory()
        {
            _menu.Show();
            _menuView.InvokeSelectCategory(Furniture);
            _menuView.InvokeSelectCategory(Utility);
            _menuView.InvokeSelectBack();
            _menuView.InvokeSelectBack();
            _menuView.InvokeSelectCategory(Structure);

            AssertMenuIsShowingStructureCategory();
        }
    }
}
