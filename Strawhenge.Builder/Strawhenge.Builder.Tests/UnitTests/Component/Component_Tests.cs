using Xunit;

namespace Strawhenge.Builder.Tests.UnitTests
{
    public partial class Component_Tests
    {
        [Theory]
        [InlineData(null, "")]
        [InlineData("", "")]
        [InlineData(" ", "")]
        [InlineData("Wood", "Wood")]
        public void Identifier_ShouldBeExpected(string identifier, string expected)
        {
            var component = new Component(identifier);

            Assert.Equal(expected, component.Identifier);
        }

        static object[] Case(params object[] objects) => objects;
    }
}
