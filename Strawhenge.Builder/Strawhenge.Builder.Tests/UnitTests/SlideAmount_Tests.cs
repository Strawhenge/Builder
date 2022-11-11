using System;
using Strawhenge.Common.Ranges;
using Xunit;

namespace Strawhenge.Builder.Tests.UnitTests
{
    public class SlideAmount_Tests
    {
        [Fact]
        public void Slide_delta_should_be_entered_amount_when_total_is_within_range()
        {
            var sut = new SlideAmount(-10, 10);

            Assert.True(sut.Slide(5, out var delta));
            Assert.Equal(5, delta);

            Assert.True(sut.Slide(-10, out delta));
            Assert.Equal(-10, delta);
        }

        [Fact]
        public void Slide_delta_should_be_difference_to_max_when_total_amount_reaches_max()
        {
            var sut = new SlideAmount(-10, 10);
            sut.Slide(6, out _);

            Assert.True(sut.Slide(11, out var delta));
            Assert.Equal(4, delta);
        }

        [Fact]
        public void Slide_delta_should_be_difference_to_min_when_total_amount_reaches_min()
        {
            var sut = new SlideAmount(-10, 10);
            sut.Slide(-9, out _);

            Assert.True(sut.Slide(-5, out var delta));
            Assert.Equal(-1, delta);
        }

        [Fact]
        public void Slide_should_not_change_when_zero_entered()
        {
            var sut = new SlideAmount(-10, 10);

            Assert.False(sut.Slide(0, out var delta));
            Assert.Equal(0, delta);
        }

        [Fact]
        public void Slide_should_not_increase_when_at_max()
        {
            var sut = new SlideAmount(-10, 10);

            sut.Slide(10, out _);

            Assert.False(sut.Slide(5, out var delta));
            Assert.Equal(0, delta);
        }

        [Fact]
        public void Slide_should_not_decrease_when_at_min()
        {
            var sut = new SlideAmount(-10, 10);

            sut.Slide(-10, out _);

            Assert.False(sut.Slide(-5, out var delta));
            Assert.Equal(0, delta);
        }
    }
}