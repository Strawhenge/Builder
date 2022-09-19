using Strawhenge.Builder.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            AssertMenuItemsAreListed(items, category);
        }

        [Fact]
        public void ItemsShouldBeListedInCategory()
        {
            var items = SampleBuildItem.GetItemsInStructureCategory();
            var category = _sut.Create(items);

            Assert.NotNull(category);
            Assert.Empty(category.Items);

            var structures = Assert.Single(category.Subcategories);
            Assert.Equal(SampleBuildItem.STRUCTURE, structures.Name);

            AssertMenuItemsAreListed(items, structures);
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
            Assert.Equal(SampleBuildItem.STRUCTURE, structures.Name);
            AssertMenuItemsAreListed(structureItems, structures);

            var furniture = category.Subcategories[1];
            Assert.Equal(SampleBuildItem.FURNITURE, furniture.Name);
            AssertMenuItemsAreListed(furnitureItems, furniture);
        }

        void AssertMenuItemsAreListed(SampleBuildItem[] items, MenuCategory category)
        {
            Assert.Equal(items.Length, category.Items.Count);

            for (int i = 0; i < items.Length; i++)
                Assert.Equal(items[i].Name, category.Items[i].Name);
        }
    }

    class SampleBuildItem : ICategorizable
    {
        public const string STRUCTURE = "Structure";
        public const string FURNITURE = "Furniture";

        public static SampleBuildItem Wall { get; } = new SampleBuildItem { Name = nameof(Wall) };

        public static SampleBuildItem Floor { get; } = new SampleBuildItem { Name = nameof(Floor) };

        public static SampleBuildItem Roof { get; } = new SampleBuildItem { Name = nameof(Roof) };

        public static SampleBuildItem Chair { get; } = new SampleBuildItem { Name = nameof(Chair) };

        public static SampleBuildItem Table { get; } = new SampleBuildItem { Name = nameof(Table) };

        public string Name { get; set; }

        public Maybe<Category> Category { get; set; } = Maybe.None<Category>();

        public SampleBuildItem InCategory(string category)
        {
            Category = Maybe.Some(new Category(category));
            return this;
        }

        public static SampleBuildItem[] GetItemsWithoutCategories()
        {
            return new SampleBuildItem[]
            {
                Wall,
                Floor,
                Roof,
                Chair,
                Table
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
    }
}
