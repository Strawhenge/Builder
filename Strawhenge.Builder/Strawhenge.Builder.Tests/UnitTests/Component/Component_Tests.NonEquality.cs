using System.Collections.Generic;
using Xunit;

namespace Strawhenge.Builder.Tests.UnitTests
{
    public partial class Component_Tests
    {
        public static IEnumerable<object[]> NonMatchingComponentNames => new object[][]
        {
            Case("Wood", null),
            Case("Wood", "Metal")
        };

        [Theory]
        [MemberData(nameof(NonMatchingComponentNames))]
        public void Is_ShouldBeFalse(string identifier1, string identifier2)
        {
            var component1 = new Component(identifier1);
            var component2 = new Component(identifier2);

            Assert.False(component1.Is(component2));
        }

        [Theory]
        [MemberData(nameof(NonMatchingComponentNames))]
        public void Equals_ShouldBeFalse(string identifier1, string identifier2)
        {
            var component1 = new Component(identifier1);
            var component2 = new Component(identifier2);

            Assert.False(component1.Equals(component2));
        }

        [Theory]
        [MemberData(nameof(NonMatchingComponentNames))]
        public void EqualityOperator_ShouldBeFalse(string identifier1, string identifier2)
        {
            var component1 = new Component(identifier1);
            var component2 = new Component(identifier2);

            Assert.False(component1 == component2);
        }

        [Theory]
        [MemberData(nameof(NonMatchingComponentNames))]
        public void InequalityOperator_ShouldBeTrue(string identifier1, string identifier2)
        {
            var component1 = new Component(identifier1);
            var component2 = new Component(identifier2);

            Assert.True(component1 != component2);
        }

        [Theory]
        [MemberData(nameof(NonMatchingComponentNames))]
        public void DefaultComparer_ShouldNotMatch(string identifier1, string identifier2)
        {
            var component1 = new Component(identifier1);
            var component2 = new Component(identifier2);

            Assert.NotEqual(component1, component2);
        }
    }
}
