using Strawhenge.Builder.Menu;
using System;
using System.Linq;
using Xunit;

namespace Strawhenge.Builder.Tests.Menu
{
    public class MenuCategoryFactoryTests
    {
        readonly MenuCategoryFactory<SampleBuildItem> _sut = new MenuCategoryFactory<SampleBuildItem>();
        readonly Action<SampleBuildItem> _onSelect;
        SampleBuildItem _selectedItem;

        public MenuCategoryFactoryTests()
        {
            _sut = new MenuCategoryFactory<SampleBuildItem>();
            _onSelect = x => _selectedItem = x;
        }

        [Fact]
        public void CreateEmptyCategory()
        {
            var mainCategory = _sut.Create(Enumerable.Empty<SampleBuildItem>(), x => { });

            Assert.NotNull(mainCategory);
            Assert.Empty(mainCategory.Items);
            Assert.Empty(mainCategory.Subcategories);
        }

        [Fact]
        public void ItemsShouldBeListed()
        {
            var items = SampleBuildItem.GetItemsWithoutCategories();
            var mainCategory = _sut.Create(items, _onSelect);

            Assert.NotNull(mainCategory);
            Assert.Empty(mainCategory.Subcategories);

            VerifyCategory(items, mainCategory, string.Empty);
        }

        [Fact]
        public void ItemsShouldBeListedInCategory()
        {
            var items = SampleBuildItem.GetItemsInStructureCategory();
            var mainCategory = _sut.Create(items, _onSelect);

            Assert.NotNull(mainCategory);
            Assert.Empty(mainCategory.Items);

            var structures = Assert.Single(mainCategory.Subcategories);
            VerifyCategory(items, structures, SampleBuildItem.STRUCTURE);
        }

        [Fact]
        public void ItemsShouldBeListedInCategories()
        {
            var structureItems = SampleBuildItem.GetItemsInStructureCategory();
            var furnitureItems = SampleBuildItem.GetItemsInFurnitureCategory();

            var items = structureItems.Concat(furnitureItems);
            var mainCategory = _sut.Create(items, _onSelect);

            Assert.NotNull(mainCategory);
            Assert.Empty(mainCategory.Items);

            Assert.Equal(2, mainCategory.Subcategories.Count);

            var structures = mainCategory.Subcategories[0];
            VerifyCategory(structureItems, structures, SampleBuildItem.STRUCTURE);

            var furniture = mainCategory.Subcategories[1];
            VerifyCategory(furnitureItems, furniture, SampleBuildItem.FURNITURE);
        }

        [Fact]
        public void ItemsShouldBeListedInSubCategories()
        {
            var items = SampleBuildItem.GetItemsInDecorativeFurnitureCategory();
            var mainCategory = _sut.Create(items, _onSelect);

            Assert.NotNull(mainCategory);
            Assert.Empty(mainCategory.Items);

            var furniture = Assert.Single(mainCategory.Subcategories);
            Assert.Equal(SampleBuildItem.FURNITURE, furniture.Name);
            Assert.Empty(furniture.Items);

            var decorativeFurniture = Assert.Single(furniture.Subcategories);
            Assert.Empty(decorativeFurniture.Subcategories);
            VerifyCategory(items, decorativeFurniture, SampleBuildItem.DECORATIVE_FURNITURE);
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

            var mainCategory = _sut.Create(items, _onSelect);

            Assert.NotNull(mainCategory);
            Assert.Equal(2, mainCategory.Subcategories.Count);
            VerifyCategory(uncategorizedItems, mainCategory, string.Empty);

            var structures = mainCategory.Subcategories[0];
            VerifyCategory(structureItems, structures, SampleBuildItem.STRUCTURE);

            var furniture = mainCategory.Subcategories[1];
            VerifyCategory(furnitureItems, furniture, SampleBuildItem.FURNITURE);

            var decorativeFurniture = Assert.Single(furniture.Subcategories);
            Assert.Empty(decorativeFurniture.Subcategories);
            VerifyCategory(decorativeFurnitureItems, decorativeFurniture, SampleBuildItem.DECORATIVE_FURNITURE);
        }

        [Fact]
        public void ShouldInvokeItemSelectCallback()
        {
            var items = SampleBuildItem.GetItemsWithoutCategories()
                .Concat(SampleBuildItem.GetItemsInStructureCategory())
                .Concat(SampleBuildItem.GetItemsInFurnitureCategory())
                .Concat(SampleBuildItem.GetItemsInDecorativeFurnitureCategory())
                .ToArray();

            var mainCategory = _sut.Create(items, _onSelect);

            mainCategory
                .Items
                .Single(x => x.Name == SampleBuildItem.Barrel.Name)
                .Select();

            VerifySelectedItem(SampleBuildItem.Barrel);

            mainCategory.Subcategories
                .Single(x => x.Name == SampleBuildItem.FURNITURE)
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

    class SampleBuildItem : ICategorizable
    {
        public const string STRUCTURE = "Structure";
        public const string FURNITURE = "Furniture";
        public const string DECORATIVE_FURNITURE = "Decorative Furniture";

        public static SampleBuildItem Wall { get; } = new SampleBuildItem { Name = nameof(Wall) };

        public static SampleBuildItem Floor { get; } = new SampleBuildItem { Name = nameof(Floor) };

        public static SampleBuildItem Roof { get; } = new SampleBuildItem { Name = nameof(Roof) };

        public static SampleBuildItem Chair { get; } = new SampleBuildItem { Name = nameof(Chair) };

        public static SampleBuildItem Table { get; } = new SampleBuildItem { Name = nameof(Table) };

        public static SampleBuildItem Box { get; } = new SampleBuildItem { Name = nameof(Box) };

        public static SampleBuildItem Barrel { get; } = new SampleBuildItem { Name = nameof(Barrel) };

        public static SampleBuildItem Poster { get; } = new SampleBuildItem { Name = nameof(Poster) };

        public static SampleBuildItem Painting { get; } = new SampleBuildItem { Name = nameof(Painting) };

        public string Name { get; set; }

        public Maybe<Category> Category { get; set; } = Maybe.None<Category>();

        public SampleBuildItem InCategory(string category)
        {
            Category = Maybe.Some(new Category(category));
            return this;
        }

        public SampleBuildItem InCategory(string category, string parentCategory)
        {
            Category = Maybe.Some(new Category(category, new Category(parentCategory)));
            return this;
        }

        public static SampleBuildItem[] GetItemsWithoutCategories()
        {
            return new SampleBuildItem[]
            {
                Box,
                Barrel
            };
        }

        public static SampleBuildItem[] GetItemsInStructureCategory()
        {
            return new SampleBuildItem[]
            {
                Wall.InCategory(STRUCTURE),
                Floor.InCategory(STRUCTURE),
                Roof.InCategory(STRUCTURE)
            };
        }

        public static SampleBuildItem[] GetItemsInFurnitureCategory()
        {
            return new SampleBuildItem[]
            {
                Chair.InCategory(FURNITURE),
                Table.InCategory(FURNITURE)
            };
        }

        public static SampleBuildItem[] GetItemsInDecorativeFurnitureCategory()
        {
            return new SampleBuildItem[]
            {
                Poster.InCategory(DECORATIVE_FURNITURE, parentCategory: FURNITURE),
                Painting.InCategory(DECORATIVE_FURNITURE, parentCategory: FURNITURE)
            };
        }
    }
}
