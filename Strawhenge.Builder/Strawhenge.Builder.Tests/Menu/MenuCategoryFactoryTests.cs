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


    }

    class SampleBuildItem : ICategorizable
    {
        public static SampleBuildItem Wall { get; } = new SampleBuildItem { Name = nameof(Wall) };

        public static SampleBuildItem Floor { get; } = new SampleBuildItem { Name = nameof(Floor) };

        public static SampleBuildItem Roof { get; } = new SampleBuildItem { Name = nameof(Roof) };

        public string Name { get; set; }

        public static SampleBuildItem[] GetItemsWithoutCategories()
        {
            return new SampleBuildItem[]
            {
                Wall,
                Floor,
                Roof
            };
        }
    }
}
