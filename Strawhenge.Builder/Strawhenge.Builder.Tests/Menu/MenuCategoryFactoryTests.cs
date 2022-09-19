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

            Assert.Equal(items.Length, category.Items.Count);

            for (int i = 0; i < items.Length; i++)
                Assert.Equal(items[i].Name, category.Items[i].Name);

            Assert.Empty(category.Subcategories);
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

            Assert.Equal(items.Length, structures.Items.Count);

            for (int i = 0; i < items.Length; i++)
                Assert.Equal(items[i].Name, structures.Items[i].Name);
        }
    }

    class SampleBuildItem : ICategorizable
    {
        public const string STRUCTURE = "Structure";

        public static SampleBuildItem Wall { get; } = new SampleBuildItem { Name = nameof(Wall) };

        public static SampleBuildItem Floor { get; } = new SampleBuildItem { Name = nameof(Floor) };

        public static SampleBuildItem Roof { get; } = new SampleBuildItem { Name = nameof(Roof) };

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
                Roof
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
    }
}
