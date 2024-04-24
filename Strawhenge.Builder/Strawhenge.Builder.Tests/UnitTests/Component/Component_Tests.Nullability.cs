using Xunit;

namespace Strawhenge.Builder.Tests.UnitTests
{
    public partial class Component_Tests
    {
        [Fact]
        public void EqualityOperator_ShouldBeTrue_WhenBothReferencesAreNull()
        {
            Component first = null;
            Component second = null;

            Assert.True(first == second);
        }

        [Fact]
        public void EqualityOperator_ShouldBeFalse_WhenFirstReferenceIsNull()
        {
            Component first = null;
            Component second = new Component("Glue");

            Assert.False(first == second);
        }

        [Fact]
        public void EqualityOperator_ShouldBeFalse_WhenSecondReferenceIsNull()
        {
            Component first = new Component("Glue");
            Component second = null;

            Assert.False(first == second);
        }

        [Fact]
        public void InequalityOperator_ShouldBeFalse_WhenBothReferencesAreNull()
        {
            Component first = null;
            Component second = null;

            Assert.False(first != second);
        }

        [Fact]
        public void InequalityOperator_ShouldBeTrue_WhenFirstReferenceIsNull()
        {
            Component first = null;
            Component second = new Component("Glue");

            Assert.True(first != second);
        }

        [Fact]
        public void InequalityOperator_ShouldBeTrue_WhenSecondReferenceIsNull()
        {
            Component first = new Component("Glue");
            Component second = null;

            Assert.True(first != second);
        }
    }
}