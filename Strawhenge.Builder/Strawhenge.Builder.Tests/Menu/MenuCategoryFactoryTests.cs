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
    }

    class SampleBuildItem
    {
    }
}
