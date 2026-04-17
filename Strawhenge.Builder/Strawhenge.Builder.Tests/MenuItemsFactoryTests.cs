using Strawhenge.Builder.Menu;
using System;
using System.Linq;
using Xunit;

namespace Strawhenge.Builder.Tests.Menu
{
    public class MenuItemsFactoryTests
    {
        readonly MenuItemsFactory<SampleBuildItem> _sut = new MenuItemsFactory<SampleBuildItem>();
        readonly Action<SampleBuildItem> _onSelect;
        SampleBuildItem _selectedItem;

        public MenuItemsFactoryTests()
        {
            _sut = new MenuItemsFactory<SampleBuildItem>();
            _onSelect = x => _selectedItem = x;
        }

        [Fact]
        public void CreateEmptyCategory()
        {
            var mainCategory = _sut.CreateMainCategory(Enumerable.Empty<SampleBuildItem>(), x => { });

            Assert.NotNull(mainCategory);
            Assert.Empty(mainCategory.Items);
            Assert.Empty(mainCategory.Subcategories);
        }

        [Fact]
        public void ItemsShouldBeListed()
        {
            var items = SampleBuildItem.GetItemsWithoutCategories();
            var mainCategory = _sut.CreateMainCategory(items, _onSelect);

            Assert.NotNull(mainCategory);
            Assert.Empty(mainCategory.Subcategories);

            VerifyCategory(items, mainCategory, string.Empty);
        }

        [Fact]
        public void ItemsShouldBeListedInCategory()
        {
            var items = SampleBuildItem.GetItemsInStructureCategory();
            var mainCategory = _sut.CreateMainCategory(items, _onSelect);

            Assert.NotNull(mainCategory);
            Assert.Empty(mainCategory.Items);

            var structures = Assert.Single(mainCategory.Subcategories);
            VerifyCategory(items, structures, SampleBuildItem.Structure);
        }

        [Fact]
        public void ItemsShouldBeListedInCategories()
        {
            var structureItems = SampleBuildItem.GetItemsInStructureCategory();
            var furnitureItems = SampleBuildItem.GetItemsInFurnitureCategory();

            var items = structureItems.Concat(furnitureItems);
            var mainCategory = _sut.CreateMainCategory(items, _onSelect);

            Assert.NotNull(mainCategory);
            Assert.Empty(mainCategory.Items);

            Assert.Equal(2, mainCategory.Subcategories.Count);

            var structures = mainCategory.Subcategories[0];
            VerifyCategory(structureItems, structures, SampleBuildItem.Structure);

            var furniture = mainCategory.Subcategories[1];
            VerifyCategory(furnitureItems, furniture, SampleBuildItem.Furniture);
        }

        [Fact]
        public void ItemsShouldBeListedInSubCategories()
        {
            var items = SampleBuildItem.GetItemsInDecorativeFurnitureCategory();
            var mainCategory = _sut.CreateMainCategory(items, _onSelect);

            Assert.NotNull(mainCategory);
            Assert.Empty(mainCategory.Items);

            var furniture = Assert.Single(mainCategory.Subcategories);
            Assert.Equal(SampleBuildItem.Furniture, furniture.Name);
            Assert.Empty(furniture.Items);

            var decorativeFurniture = Assert.Single(furniture.Subcategories);
            Assert.Empty(decorativeFurniture.Subcategories);
            VerifyCategory(items, decorativeFurniture, SampleBuildItem.DecorativeFurniture);
        }

        [Fact]
        public void ItemsShouldBeListedWithItemInCategoriesAndWithSubCategories()
        {
            var uncategorizedItems = SampleBuildItem.GetItemsWithoutCategories();
            var structureItems = SampleBuildItem.GetItemsInStructureCategory();
            var furnitureItems = SampleBuildItem.GetItemsInFurnitureCategory();
            var decorativeFurnitureItems = SampleBuildItem.GetItemsInDecorativeFurnitureCategory();

            var items = uncategorizedItems
                .Concat(structureItems)
                .Concat(furnitureItems)
                .Concat(decorativeFurnitureItems)
                .ToArray();

            var mainCategory = _sut.CreateMainCategory(items, _onSelect);

            Assert.NotNull(mainCategory);
            Assert.Equal(2, mainCategory.Subcategories.Count);
            VerifyCategory(uncategorizedItems, mainCategory, string.Empty);

            var structures = mainCategory.Subcategories[0];
            VerifyCategory(structureItems, structures, SampleBuildItem.Structure);

            var furniture = mainCategory.Subcategories[1];
            VerifyCategory(furnitureItems, furniture, SampleBuildItem.Furniture);

            var decorativeFurniture = Assert.Single(furniture.Subcategories);
            Assert.Empty(decorativeFurniture.Subcategories);
            VerifyCategory(decorativeFurnitureItems, decorativeFurniture, SampleBuildItem.DecorativeFurniture);
        }

        [Fact]
        public void ShouldInvokeItemSelectCallback()
        {
            var items = SampleBuildItem.GetItemsWithoutCategories()
                .Concat(SampleBuildItem.GetItemsInStructureCategory())
                .Concat(SampleBuildItem.GetItemsInFurnitureCategory())
                .Concat(SampleBuildItem.GetItemsInDecorativeFurnitureCategory())
                .ToArray();

            var mainCategory = _sut.CreateMainCategory(items, _onSelect);

            mainCategory
                .Items
                .Single(x => x.Name == SampleBuildItem.Barrel.Name)
                .Select();

            VerifySelectedItem(SampleBuildItem.Barrel);

            mainCategory.Subcategories
                .Single(x => x.Name == SampleBuildItem.Furniture)
                .Items
                .Single(x => x.Name == SampleBuildItem.Table.Name)
                .Select();

            VerifySelectedItem(SampleBuildItem.Table);
        }

        void VerifyCategory(SampleBuildItem[] items, MenuCategory category, string expectedName)
        {
            Assert.Equal(expectedName, category.Name);
            Assert.Equal(items.Length, category.Items.Count);

            for (int i = 0; i < items.Length; i++)
                Assert.Equal(items[i].Name, category.Items[i].Name);
        }

        void VerifySelectedItem(SampleBuildItem item)
        {
            Assert.Equal(item, _selectedItem);
        }
    }
}
