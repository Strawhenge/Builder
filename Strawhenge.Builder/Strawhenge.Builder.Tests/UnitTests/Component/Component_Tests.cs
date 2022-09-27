using System.Collections.Generic;
using Xunit;

namespace Strawhenge.Builder.Tests.UnitTests
{
    public class Component_Tests
    {
        [Theory]
        [MemberData(nameof(MatchingComponentNames))]
        public void Is_ShouldBeTrue(string identifier1, string identifier2)
        {
            var component1 = new Component(identifier1);
            var component2 = new Component(identifier2);

            Assert.True(component1.Is(component2));
        }

        [Theory]
        [MemberData(nameof(NonMatchingComponentNames))]
        public void Is_ShouldBeFalse(string identifier1, string identifier2)
        {
            var component1 = new Component(identifier1);
            var component2 = new Component(identifier2);

            Assert.False(component1.Is(component2));
        }

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

        public static IEnumerable<object[]> MatchingComponentNames => new object[][]
        {
            Case("", null),
            Case("", ""),
            Case("Wood", "Wood"),
            Case("Wood", "wood"),
            Case("Wood", "Wood ")
        };

        public static IEnumerable<object[]> NonMatchingComponentNames => new object[][]
        {
            Case("Wood", null),
            Case("Wood", "Metal")
        };

        static object[] Case(params object[] objects) => objects;
    }
}
