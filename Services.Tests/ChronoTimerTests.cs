using Services.Interfaces;
using Xunit;

namespace Services.Tests
{
    public class ChronoTimerTests
    {
        private IChronoTimer chrono;

        public ChronoTimerTests()
        {
            chrono = ChronoTimer.Create(null);
        }

        [Fact]
        public void When_the_class_is_initialized_then_the_value_is_initialized()
        {
            Assert.Equal("00:00:00", chrono.Value);
        }

        [Theory]
        [InlineData(1, "00:00:01")]
        [InlineData(60, "00:01:00")]
        [InlineData(3600, "01:00:00")]
        [InlineData(3672, "01:01:12")]
        [InlineData(86400, "00:00:00")]
        [InlineData(86401, "00:00:01")]
        public void When_the_chrono_receives_n_seconds_then_it_shows_in_hour_format(int seconds, string result)
        {
            chrono.InitializeCurrentSecond(seconds);
            Assert.Equal(result, chrono.Value);
        }
    }
}