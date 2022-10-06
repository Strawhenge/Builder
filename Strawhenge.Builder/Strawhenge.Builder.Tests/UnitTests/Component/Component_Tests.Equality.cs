using System.Collections.Generic;
using Xunit;

namespace Strawhenge.Builder.Tests.UnitTests
{
    public partial class Component_Tests
    {
        public static IEnumerable<object[]> MatchingComponentNames => new object[][]
        {
            Case("", null),
            Case("", ""),
            Case("Wood", "Wood"),
            Case("Wood", "wood"),
            Case("Wood", "Wood ")
        };

        [Theory]
        [MemberData(nameof(MatchingComponentNames))]
        public void Is_ShouldBeTrue(string identifier1, string identifier2)
        {
            var component1 = new Component(identifier1);
            var component2 = new Component(identifier2);

            Assert.True(component1.Is(component2));
        }

        [Theory]
        [MemberData(nameof(MatchingComponentNames))]
        public void Equals_ShouldBeTrue(string identifier1, string identifier2)
        {
            var component1 = new Component(identifier1);
            var component2 = new Component(identifier2);

            Assert.True(component1.Equals(component2));
        }

        [Theory]
        [MemberData(nameof(MatchingComponentNames))]
        public void EqualityOperator_ShouldBeTrue(string identifier1, string identifier2)
        {
            var component1 = new Component(identifier1);
            var component2 = new Component(identifier2);

            Assert.True(component1 == component2);
        }

        [Theory]
        [MemberData(nameof(MatchingComponentNames))]
        public void InequalityOperator_ShouldBeFalse(string identifier1, string identifier2)
        {
            var component1 = new Component(identifier1);
            var component2 = new Component(identifier2);

            Assert.False(component1 != component2);
        }

        [Theory]
        [MemberData(nameof(MatchingComponentNames))]
        public void DefaultComparer_ShouldMatch(string identifier1, string identifier2)
        {
            var component1 = new Component(identifier1);
            var component2 = new Component(identifier2);

            Assert.Equal(component1, component2);
        }
    }
}
