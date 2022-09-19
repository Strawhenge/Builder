using Strawhenge.Builder.Menu;
using System.Linq;
using Xunit;

namespace Strawhenge.Builder.Tests.Menu
{
    public class MenuCategoryFactoryTests
    {
        readonly MenuCategoryFactory<SampleBuildItem> _sut = new MenuCategoryFactory<SampleBuildItem>();

        [Fact]
        public void CreateEmptyCategory()
        {
            var category = _sut.Create(Enumerable.Empty<SampleBuildItem>());

            Assert.NotNull(category);
            Assert.Empty(category.Items);
            Assert.Empty(category.Subcategories);
        }

        [Fact]
        public void ItemsShouldBeListed()
        {
            var items = SampleBuildItem.GetItemsWithoutCategories();
            var category = _sut.Create(items);

            Assert.NotNull(category);
            Assert.Empty(category.Subcategories);

            VerifyCategory(items, category, string.Empty);
        }

        [Fact]
        public void ItemsShouldBeListedInCategory()
        {
            var items = SampleBuildItem.GetItemsInStructureCategory();
            var category = _sut.Create(items);

            Assert.NotNull(category);
            Assert.Empty(category.Items);

            var structures = Assert.Single(category.Subcategories);
            VerifyCategory(items, structures, SampleBuildItem.STRUCTURE);
        }

        [Fact]
        public void ItemsShouldBeListedInCategories()
        {
            var structureItems = SampleBuildItem.GetItemsInStructureCategory();
            var furnitureItems = SampleBuildItem.GetItemsInFurnitureCategory();

            var items = structureItems.Concat(furnitureItems);
            var category = _sut.Create(items);

            Assert.NotNull(category);
            Assert.Empty(category.Items);

            Assert.Equal(2, category.Subcategories.Count);

            var structures = category.Subcategories[0];
            VerifyCategory(structureItems, structures, SampleBuildItem.STRUCTURE);

            var furniture = category.Subcategories[1];
            VerifyCategory(furnitureItems, furniture, SampleBuildItem.FURNITURE);
        }

        [Fact]
        public void ItemsShouldBeListedInSubCategories()
        {
            var items = SampleBuildItem.GetItemsInDecorativeFurnitureCategory();
            var category = _sut.Create(items);

            Assert.NotNull(category);
            Assert.Empty(category.Items);

            var furniture = Assert.Single(category.Subcategories);
            Assert.Equal(SampleBuildItem.FURNITURE, furniture.Name);
            Assert.Empty(furniture.Items);

            var decorativeFurniture = Assert.Single(furniture.Subcategories);
            Assert.Empty(decorativeFurniture.Subcategories);
            VerifyCategory(items, decorativeFurniture, SampleBuildItem.DECORATIVE_FURNITURE);
        }

        void VerifyCategory(SampleBuildItem[] items, MenuCategory category, string expectedName)
        {
            Assert.Equal(expectedName, category.Name);
            Assert.Equal(items.Length, category.Items.Count);

            for (int i = 0; i < items.Length; i++)
                Assert.Equal(items[i].Name, category.Items[i].Name);
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
