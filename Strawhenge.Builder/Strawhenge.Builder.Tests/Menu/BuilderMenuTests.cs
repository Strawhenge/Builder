using Strawhenge.Builder.Menu;
using Xunit;

namespace Strawhenge.Builder.Tests.Menu
{
    public partial class BuilderMenuTests
    {
        readonly MenuCategory _mainCategory;
        readonly BuilderMenu _menu;
        readonly MenuViewFake _menuView;

        public BuilderMenuTests()
        {
            _mainCategory = CreateMainCategory();
            _menuView = new MenuViewFake();
            _menu = new BuilderMenu(_menuView);
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
            _menu.Show(_mainCategory);

            AssertMenuIsShowingMainCategory();
        }

        [Fact]
        public void Hide()
        {
            _menu.Show(_mainCategory);
            _menu.Hide();

            AssertMenuIsHidden();
        }

        [Fact]
        public void SelectCategory()
        {
            _menu.Show(_mainCategory);
            _menuView.InvokeSelectCategory(Furniture);

            AssertMenuIsShowingFurnitureCategory();
        }

        [Fact]
        public void SelectCategoryThenAnotherCategory()
        {
            _menu.Show(_mainCategory);
            _menuView.InvokeSelectCategory(Furniture);
            _menuView.InvokeSelectCategory(Utility);

            AssertMenuIsShowingUtilityCategory();
        }

        [Fact]
        public void SelectCategoryThenGoBack()
        {
            _menu.Show(_mainCategory);
            _menuView.InvokeSelectCategory(Furniture);
            _menuView.InvokeSelectBack();

            AssertMenuIsShowingMainCategory();
        }

        [Fact]
        public void SelectCategoryThenAnotherCategoryThenGoBack()
        {
            _menu.Show(_mainCategory);
            _menuView.InvokeSelectCategory(Furniture);
            _menuView.InvokeSelectCategory(Utility);
            _menuView.InvokeSelectBack();

            AssertMenuIsShowingFurnitureCategory();
        }

        [Fact]
        public void SelectCategoryThenAnotherCategoryThenGoBackThenGoBackAgain()
        {
            _menu.Show(_mainCategory);
            _menuView.InvokeSelectCategory(Furniture);
            _menuView.InvokeSelectCategory(Utility);
            _menuView.InvokeSelectBack();
            _menuView.InvokeSelectBack();

            AssertMenuIsShowingMainCategory();
        }

        [Fact]
        public void SelectCategoryThenAnotherCategoryThenGoBackThenGoBackAgainThenSelectAnotherCategory()
        {
            _menu.Show(_mainCategory);
            _menuView.InvokeSelectCategory(Furniture);
            _menuView.InvokeSelectCategory(Utility);
            _menuView.InvokeSelectBack();
            _menuView.InvokeSelectBack();
            _menuView.InvokeSelectCategory(Structure);

            AssertMenuIsShowingStructureCategory();
        }

        [Fact]
        public void SelectItem()
        {
            _menu.Show(_mainCategory);
            _menuView.InvokeSelectCategory(Furniture);
            _menuView.InvokeSelectItem(Table);

            AssertMenuIsHidden();
            AssertItemSelected(Table);
        }

        [Fact]
        public void SelectCategoryThenAnotherCategoryThenGoBackThenSelectItem()
        {
            _menu.Show(_mainCategory);
            _menuView.InvokeSelectCategory(Furniture);
            _menuView.InvokeSelectCategory(Utility);
            _menuView.InvokeSelectBack();
            _menuView.InvokeSelectItem(Chair);

            AssertMenuIsHidden();
            AssertItemSelected(Chair);
        }

        [Fact]
        public void SelectExit()
        {
            _menu.Show(_mainCategory);
            _menuView.InvokeSelectExit();

            AssertMenuIsHidden();
        }
    }
}
