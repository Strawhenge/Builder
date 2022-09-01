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
    }
}
