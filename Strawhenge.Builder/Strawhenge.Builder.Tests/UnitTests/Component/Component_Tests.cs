using Xunit;

namespace Strawhenge.Builder.Tests.UnitTests
{
    public class Component_Tests
    {
        [Theory]
        [InlineData("", null)]
        [InlineData("", "")]
        [InlineData("Wood", "Wood")]
        [InlineData("Wood", "wood")]
        [InlineData("Wood", "Wood ")]
        public void Is_ShouldBeTrue(string identifier1, string identifier2)
        {
            var component1 = new Component(identifier1);
            var component2 = new Component(identifier2);

            Assert.True(component1.Is(component2));
        }

        [Theory]
        [InlineData("Wood", null)]
        [InlineData("Wood", "Metal")]
        public void Is_ShouldBeFalse(string identifier1, string identifier2)
        {
            var component1 = new Component(identifier1);
            var component2 = new Component(identifier2);

            Assert.False(component1.Is(component2));
        }
    }
}
