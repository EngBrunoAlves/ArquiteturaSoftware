namespace OpenWeather.Domain.Test.BusinessRules.Base
{
    using System;
    using OpenWeather.Domain.BusinessRules.Base;
    using Xunit;

    public class DateIntervalIsValidTest
    {
        [Fact]
        public void DateIntervalIsValidShouldTrue()
        {
            var startTime = DateTime.UtcNow.AddDays(-1);
            var endTime = DateTime.UtcNow;

            var result = DateIntervalIsValid.Execute(startTime, endTime);

            Assert.True(result);
        }

        [Fact]
        public void DateIntervalIsValidEndTimeBeforeStartTimeShouldFalse()
        {
            var startTime = DateTime.UtcNow;
            var endTime = DateTime.UtcNow.AddDays(-1);

            var result = DateIntervalIsValid.Execute(startTime, endTime);

            Assert.False(result);
        }

        [Fact]
        public void DateIntervalIsValidStartTimeNullShouldFalse()
        {
            var endTime = DateTime.UtcNow.AddDays(-1);

            var result = DateIntervalIsValid.Execute(null, endTime);

            Assert.False(result);
        }

        [Fact]
        public void DateIntervalIsValidEndTimeNullShouldFalse()
        {
            var startTime = DateTime.UtcNow.AddDays(-1);

            var result = DateIntervalIsValid.Execute(startTime, null);

            Assert.False(result);
        }

        [Fact]
        public void DateIntervalIsValidStartAndEndTimeNullShouldFalse()
        {
            var result = DateIntervalIsValid.Execute(null, null);

            Assert.False(result);
        }
    }
}